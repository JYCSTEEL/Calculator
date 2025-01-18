
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace 计价器
{

    public class DatabaseHelper
    {
        private static readonly DatabaseHelper _instance = new DatabaseHelper("database.sqlite");
        private string _connectionString;

        // 私有构造函数，防止外部实例化
        private DatabaseHelper(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
            EnsureDatabaseExists(databasePath); // 确保数据库存在
        }

        // 获取单例实例
        public static DatabaseHelper Instance => _instance;

        // 检查数据库文件是否存在，如果不存在则创建
        private void EnsureDatabaseExists(string databasePath)
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath); // 创建数据库文件
            }
            EnsureProductsTableExists();
        }

        // 检查是否存在表“产品表”，如果不存在则创建
        public void EnsureProductsTableExists()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='产品表';";
                using (var command = new SQLiteCommand(checkTableQuery, connection))
                {
                    var result = command.ExecuteScalar(); // 查询表是否存在
                    if (result == null)
                    {
                        // 创建产品表
                        string createTableQuery = @"
                    CREATE TABLE 产品表 (
                        材料 TEXT NOT NULL,
                        类型 TEXT NOT NULL,
                        单价 INTEGER NOT NULL
                    );
                ";
                        using (var createCommand = new SQLiteCommand(createTableQuery, connection))
                        {
                            createCommand.ExecuteNonQuery(); // 执行创建表的SQL语句
                        }
                    }
                }
            }
        }
        public int GetUnitPrice(string material,string type)
        {
            // 如果输入为空或全是空格，直接返回 null
            if (string.IsNullOrWhiteSpace(type))
            {
                return 0;
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // 查询指定类型的单价
                string query = "SELECT 单价 FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    object result = command.ExecuteScalar();

                    // 如果查询结果为空，返回 null，否则返回单价
                    return Convert.ToInt32(result);
                }
            }
        }
     

        // 查询所有产品数据
        public DataTable GetAllProducts()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM 产品表;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable); // 填充查询结果
                        return productsTable;
                    }
                }
            }
        }
        // 获取所有产品类型
        public List<string> GetAllProductTypes()
        {
            List<string> productTypes = new List<string>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT 类型 FROM 产品表;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productTypes.Add(reader["类型"].ToString());
                        }
                    }
                }
            }

            return productTypes;
        }
        // 获取指定材料的所有产品类型
        public List<string> GetProductTypesByMaterial(string material)
        {
            List<string> productTypes = new List<string>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT 类型 FROM 产品表 WHERE 材料 = @Material;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productTypes.Add(reader["类型"].ToString());
                        }
                    }
                }
            }

            return productTypes;
        }
        // 插入产品数据
        public void InsertProduct(string material, string type, int unitPrice)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // 插入新数据
                string insertQuery = "INSERT INTO 产品表 (材料, 类型, 单价) VALUES (@Material, @Type, @UnitPrice);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", material); // 设置参数
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    command.ExecuteNonQuery(); // 执行插入操作
                }
            }
        }
        // 更新“产品表”中的单价
        public void UpdateProductPrice(string material, string type, int newUnitPrice)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE 产品表 SET 单价 = @NewUnitPrice WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewUnitPrice", newUnitPrice); // 设置新的单价
                    command.Parameters.AddWithValue("@Material", material);        // 设置材料参数
                    command.Parameters.AddWithValue("@Type", type);                // 设置类型参数
                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }

        // 根据条件删除“产品表”中的一行数据
        public void DeleteProduct(string material, string type)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", material); // 设置材料参数
                    command.Parameters.AddWithValue("@Type", type);         // 设置类型参数
                    command.ExecuteNonQuery(); // 执行删除操作
                }
            }
        }

        // 检查记录是否存在
        public bool RecordExists(string material, string type)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // 返回是否存在
                }
            }
        }

    }

}
