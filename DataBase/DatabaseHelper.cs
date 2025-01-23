﻿

using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace 计价器
{

    public class DatabaseHelper
    {
        private static readonly DatabaseHelper _instance = new DatabaseHelper();
        private readonly string _connectionString = "server=43.166.250.145;port=3306;User=root;Database=JYCquote;Password=ZHSteel123$;";

        // 私有构造函数，防止外部实例化
        private DatabaseHelper()
        {
            EnsureDatabaseExists();
        }
        // 获取单例实例a
        public static DatabaseHelper Instance => _instance;

        // 检查数据库文件是否存在，如果不存在则创建
        private void EnsureDatabaseExists()
        {
            string databaseName = "JYCquote";

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    // 创建数据库
                    string createDbQuery = $"CREATE DATABASE IF NOT EXISTS `{databaseName}`;";
                    using (var command = new MySqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // 确保所有表存在
                    EnsureProductsTableExists(connection);
                    EnsureCustomizedTableExists(connection);
                    EnsureCalculatorTableExists(connection);
                    EnsureSetPriceTableExists(connection);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库创建或初始化失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
             
           
        }

        private void EnsureProductsTableExists(MySqlConnection connection)
        {
            string createTableQuery = @"
    CREATE TABLE IF NOT EXISTS 产品表 (
        材料 VARCHAR(255),
        类型 VARCHAR(255),
        单价 DECIMAL(10, 2)
    );";

            using (var command = new MySqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void EnsureCustomizedTableExists(MySqlConnection connection)
        {
            string createTableQuery = @"
    CREATE TABLE IF NOT EXISTS 自定义产品表 (
        材料 VARCHAR(255),
        类型 VARCHAR(255),
        名称 VARCHAR(255),
        单价 DECIMAL(10, 2),
        花样价格 DECIMAL(10, 2),
        花样数量 DECIMAL(10, 2),
        烤漆 TINYINT(1),
        金色 TINYINT(1),
        古铜色 TINYINT(1),
        铁板 TINYINT(1),
        胶板 TINYINT(1),
        玻璃 TINYINT(1),
        弧形 TINYINT(1),
        有锁 TINYINT(1),
        普通锁 TINYINT(1),
        指纹锁 TINYINT(1),
        密码锁 TINYINT(1),
        闭门器 TINYINT(1),

        门中门 TINYINT(1),
        纱窗 TINYINT(1),
        电动双开 TINYINT(1),
        电动推拉 TINYINT(1)
    );";

            using (var command = new MySqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void EnsureCalculatorTableExists(MySqlConnection connection)
        {
            string createTableQuery = @"
CREATE TABLE IF NOT EXISTS 计价表 (
    材料 VARCHAR(255),
    类型 VARCHAR(255),
    名称 VARCHAR(255),
    单价 DECIMAL(10, 2),
    长度或宽度 DECIMAL(10, 2),
    高度或深度 DECIMAL(10, 2),
    长度或宽度英尺 DECIMAL(10, 2),
    高度或深度英尺 DECIMAL(10, 2),
    平方英尺 DECIMAL(10, 2),
    花样价格 DECIMAL(10, 2),
    花样数量 DECIMAL(10, 2),
    烤漆 TINYINT(1),
    金色 TINYINT(1),
    古铜色 TINYINT(1),
    铁板 TINYINT(1),
    胶板 TINYINT(1),
    玻璃 TINYINT(1),
    弧形 TINYINT(1),
    有锁 TINYINT(1),
    普通锁 TINYINT(1),
    指纹锁 TINYINT(1),
    密码锁 TINYINT(1),
    闭门器 TINYINT(1),
    门中门 TINYINT(1),
    纱窗 TINYINT(1),
    电动双开 TINYINT(1),
    电动推拉 TINYINT(1),
    柱子价格 DECIMAL(10, 2),
    柱子数量 DECIMAL(10, 2),
    单个产品价格 DECIMAL(10, 2),
    产品数量 DECIMAL(10, 2),
    总共价格 DECIMAL(10, 2)
);";

            using (var command = new MySqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void EnsureSetPriceTableExists(MySqlConnection connection)
        {
            string createTableQuery = @"
    CREATE TABLE IF NOT EXISTS 设置单价表 (
        烤漆 DECIMAL(10, 2),
        金色 DECIMAL(10, 2),
        古铜色 DECIMAL(10, 2),
        铁板 DECIMAL(10, 2),
        胶板 DECIMAL(10, 2),
        玻璃 DECIMAL(10, 2),
        弧形 DECIMAL(10, 2),
        有锁 DECIMAL(10, 2),
        普通锁 DECIMAL(10, 2),
        指纹锁 DECIMAL(10, 2),
        密码锁 DECIMAL(10, 2),
 闭门器 DECIMAL(10, 2),
        门中门 DECIMAL(10, 2),
        纱窗 DECIMAL(10, 2),
        电动双开 DECIMAL(10, 2),
        电动推拉 DECIMAL(10, 2)
    );";

            using (var command = new MySqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }


       
public void InsertDefaultValuesIntoSetPriceTable()
{
    using (var connection = new MySqlConnection(_connectionString))
    {
        connection.Open();

        // 构造插入语句
        string insertQuery = @"
INSERT INTO 设置单价表 (
    烤漆, 金色, 古铜色, 铁板, 胶板, 玻璃, 弧形, 普通锁, 指纹锁, 密码锁, 闭门器,
    门中门, 纱窗, 电动双开, 电动推拉
) VALUES (
    @Powder, @Gold, @Bronze, @MetalSheet, @Plastic, @Glass, @Curved, @NormalLock,
    @FingerLock, @CodeLock, @Closer, @DoorInDoor, @Screen, @AutoSwing, @AutoSliding
);";

        using (var command = new MySqlCommand(insertQuery, connection))
        {
            // 设置所有参数为 0
            command.Parameters.AddWithValue("@Powder", 0);
            command.Parameters.AddWithValue("@Gold", 0);
            command.Parameters.AddWithValue("@Bronze", 0);
            command.Parameters.AddWithValue("@MetalSheet", 0);
            command.Parameters.AddWithValue("@Plastic", 0);
            command.Parameters.AddWithValue("@Glass", 0);
            command.Parameters.AddWithValue("@Curved", 0);
            command.Parameters.AddWithValue("@NormalLock", 0);
            command.Parameters.AddWithValue("@FingerLock", 0);
            command.Parameters.AddWithValue("@CodeLock", 0);

            command.Parameters.AddWithValue("@Closer", 0);
            command.Parameters.AddWithValue("@DoorInDoor", 0);
            command.Parameters.AddWithValue("@Screen", 0);
            command.Parameters.AddWithValue("@AutoSwing", 0);
            command.Parameters.AddWithValue("@AutoSliding", 0);

            command.ExecuteNonQuery(); // 执行插入操作
        }
    }
}

        public decimal GetUnitPrice(string material, string type)
        {
            // 如果输入为空或全是空格，直接返回 0
            if (string.IsNullOrWhiteSpace(material) || string.IsNullOrWhiteSpace(type))
            {
                return 0;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 查询指定类型的单价
                string query = "SELECT 单价 FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    object result = command.ExecuteScalar();

                    // 如果查询结果为空，返回 0，否则返回单价
                    return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
        }



        // 查询所有产品数据
        public DataTable GetAllProducts()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM 产品表;";
                using (var command = new MySqlCommand(selectQuery, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable); // 填充查询结果
                        return productsTable;
                    }
                }
            }
        }

        public DataTable GetAllCustomizedProducts()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM 自定义产品表;";
                using (var command = new MySqlCommand(selectQuery, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable); // 填充查询结果
                        return productsTable;
                    }
                }
            }
        }

        public DataTable GetAllCalculatorProducts()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM 计价表;";
                using (var command = new MySqlCommand(selectQuery, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable); // 填充查询结果
                        return productsTable;
                    }
                }
            }
        }



        public DataTable GetCustomizedProductsByMaterial(string material)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT * 
        FROM 自定义产品表
        WHERE 材料 = @Material;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // 填充结果到 DataTable
                        return dataTable;
                    }
                }
            }
        }

        public DataTable GetCustomizedProductsByMaterialAndType(string material, string type)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT * 
        FROM 自定义产品表
        WHERE 材料 = @Material AND 类型 = @Type;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // 填充结果到 DataTable
                        return dataTable;
                    }
                }
            }
        }

        public DataTable GetCalculatorProductsByMaterialAndTypeAndName(string material, string type, string name)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT * 
        FROM 计价表
        WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Name", name);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // 填充结果到 DataTable
                        return dataTable;
                    }
                }
            }
        }

        public List<string> GetCustomizedNamesByMaterialAndType(string material, string type)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT 名称 
        FROM 自定义产品表
        WHERE 材料 = @Material AND 类型 = @Type;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    using (var reader = command.ExecuteReader())
                    {
                        List<string> names = new List<string>();

                        while (reader.Read())
                        {
                            names.Add(reader["名称"].ToString());
                        }

                        return names;
                    }
                }
            }
        }

        public List<string> GetCalculatorNamesByMaterialAndType(string material, string type)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT 名称 
        FROM 计价表
        WHERE 材料 = @Material AND 类型 = @Type;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);
                    using (var reader = command.ExecuteReader())
                    {
                        List<string> names = new List<string>();

                        while (reader.Read())
                        {
                            names.Add(reader["名称"].ToString());
                        }

                        return names;
                    }
                }
            }
        }

        public List<string> GetCustomizedTypesByMaterial(string material)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
        SELECT DISTINCT 类型 
        FROM 自定义产品表
        WHERE 材料 = @Material;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);

                    using (var reader = command.ExecuteReader())
                    {
                        List<string> types = new List<string>();

                        while (reader.Read())
                        {
                            types.Add(reader["类型"].ToString());
                        }

                        return types;
                    }
                }
            }
        }


        // 获取所有产品类型
        public List<string> GetAllProductTypes()
        {
            List<string> productTypes = new List<string>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT 类型 FROM 产品表;";
                using (var command = new MySqlCommand(query, connection))
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

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT 类型 FROM 产品表 WHERE 材料 = @Material;";
                using (var command = new MySqlCommand(query, connection))
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
        public void InsertProduct(string material, string type, decimal unitPrice)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 插入新数据
                string insertQuery = "INSERT INTO 产品表 (材料, 类型, 单价) VALUES (@Material, @Type, @UnitPrice);";
                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", material); // 设置参数
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    command.ExecuteNonQuery(); // 执行插入操作
                }
            }
        }
        public void InsertCustomizedProduct(CustomizedProduct customizedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 插入新数据
                string insertQuery = @"INSERT INTO 自定义产品表 (
                                材料, 类型, 名称, 单价, 花样价格,  
                                烤漆, 金色, 古铜色,  
                                铁板, 胶板, 玻璃, 弧形, 有锁, 普通锁, 指纹锁, 密码锁,  
                                有柱子, 有闭门器, 门中门, 纱窗, 电动双开, 电动推拉,  
                                柱子价格, 柱子数量
                            ) VALUES (
                                @Material, @Type, @Name, @UnitPrice, @DesignPrice,  
                                @IsPowder, @IsGold, @IsBronze,  
                                @HasMetalSheet, @HasPlastic, @HasGlass, @HasCurved, @HasLock, @NormalLock, @FingerLock, @CodeLock,  
                                @HasPole, @HasCloser, @HasDoorInDoor, @HasScreen, @HasAutoSwing, @HasAutoSliding,  
                                @PolePrice, @PoleQty
                            );";

                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    // 设置主要产品属性
                    command.Parameters.AddWithValue("@Material", customizedProduct.Material);
                    command.Parameters.AddWithValue("@Type", customizedProduct.Type);
                    command.Parameters.AddWithValue("@UnitPrice", customizedProduct.UnitPrice);

                    // 设置嵌套属性 ProductProperty
                    var property = customizedProduct.Property;
                    command.Parameters.AddWithValue("@Name", property.ProductName);
                    command.Parameters.AddWithValue("@DesignPrice", property.DesignPrice);

                    // 设置布尔属性
                    command.Parameters.AddWithValue("@IsPowder", property.IsPowder);
                    command.Parameters.AddWithValue("@IsGold", property.IsGold);
                    command.Parameters.AddWithValue("@IsBronze", property.IsBronze);

                    command.Parameters.AddWithValue("@HasMetalSheet", property.HasMetalSheet);
                    command.Parameters.AddWithValue("@HasPlastic", property.HasPlastic);
                    command.Parameters.AddWithValue("@HasGlass", property.HasGlass);
                    command.Parameters.AddWithValue("@HasCurved", property.HasCurved);
                    command.Parameters.AddWithValue("@HasLock", property.HasLock);
                    command.Parameters.AddWithValue("@NormalLock", property.NormalLock);
                    command.Parameters.AddWithValue("@FingerLock", property.FingerLock);
                    command.Parameters.AddWithValue("@CodeLock", property.CodeLock);

                    command.Parameters.AddWithValue("@HasPole", property.HasPole);
                    command.Parameters.AddWithValue("@HasCloser", property.HasCloser);
                    command.Parameters.AddWithValue("@HasDoorInDoor", property.HasDoorInDoor);
                    command.Parameters.AddWithValue("@HasScreen", property.HasScreen);
                    command.Parameters.AddWithValue("@HasAutoSwing", property.HasAutoSwing);
                    command.Parameters.AddWithValue("@HasAutoSliding", property.HasAutoSliding);

                    // 设置柱子相关属性
                    command.Parameters.AddWithValue("@PolePrice", property.PolePrice);
                    command.Parameters.AddWithValue("@PoleQty", property.PoleQty);

                    command.ExecuteNonQuery(); // 执行插入操作
                }
            }
        }

        public void InsertCalculatorProduct(CalculatorProduct customizedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 插入新数据
                string insertQuery = @"INSERT INTO 计价表 (
                            材料, 类型, 名称, 单价, 长度或宽度, 高度或深度, 长度或宽度英尺, 高度或深度英尺, 平方英尺, 花样价格, 花样数量, 
                            烤漆, 金色, 古铜色, 
                            铁板, 胶板, 玻璃, 弧形, 有锁, 普通锁, 指纹锁, 密码锁, 
                            有柱子, 有闭门器, 门中门, 纱窗, 电动双开, 电动推拉, 
                            柱子价格, 柱子数量, 单个产品价格, 产品数量, 总共价格
                        ) VALUES (
                            @Material, @Type, @Name, @UnitPrice, @WidthOrLength, @HeightOrDeepth, @WidthOrLengthFeet, @HeightOrDeepthFeet, @Sqft, @DesignPrice, @DesignQty, 
                            @IsPowder, @IsGold, @IsBronze, 
                            @HasMetalSheet, @HasPlastic, @HasGlass, @HasCurved, @HasLock, @NormalLock, @FingerLock, @CodeLock, 
                            @HasPole, @HasCloser, @HasDoorInDoor, @HasScreen, @HasAutoSwing, @HasAutoSliding, 
                            @PolePrice, @PoleQty, @SinglePrice, @Qty, @TotalPrice
                        );";

                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    var property = customizedProduct.Property;

                    // 校验并设置参数，显式转换为 object
                    command.Parameters.AddWithValue("@Material",
                        string.IsNullOrWhiteSpace(customizedProduct.Material) ? (object)DBNull.Value : customizedProduct.Material);
                    command.Parameters.AddWithValue("@Type",
                        string.IsNullOrWhiteSpace(customizedProduct.Type) ? (object)DBNull.Value : customizedProduct.Type);
                    command.Parameters.AddWithValue("@Name",
                        string.IsNullOrWhiteSpace(property?.ProductName) ? (object)DBNull.Value : property.ProductName);

                    command.Parameters.AddWithValue("@UnitPrice", customizedProduct.UnitPrice);
                    command.Parameters.AddWithValue("@SinglePrice", customizedProduct.SinglePrice);
                    command.Parameters.AddWithValue("@Qty", customizedProduct.Qty);
                    command.Parameters.AddWithValue("@TotalPrice", customizedProduct.TotalPrice);

                    // 其他参数校验和绑定
                    command.Parameters.AddWithValue("@WidthOrLength", customizedProduct.WidthOrLength);
                    command.Parameters.AddWithValue("@HeightOrDeepth", customizedProduct.HeightOrDeepth);
                    command.Parameters.AddWithValue("@WidthOrLengthFeet", customizedProduct.WidthOrLengthFeet);
                    command.Parameters.AddWithValue("@HeightOrDeepthFeet", customizedProduct.HeightOrDeepthFeet);
                    command.Parameters.AddWithValue("@Sqft", customizedProduct.Sqft);
                    command.Parameters.AddWithValue("@DesignPrice", property?.DesignPrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DesignQty", customizedProduct.DesignQty);

                    // 布尔值转换为数据库支持的整数
                    command.Parameters.AddWithValue("@IsPowder", property?.IsPowder == true ? 1 : 0);
                    command.Parameters.AddWithValue("@IsGold", property?.IsGold == true ? 1 : 0);
                    command.Parameters.AddWithValue("@IsBronze", property?.IsBronze == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasMetalSheet", property?.HasMetalSheet == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasPlastic", property?.HasPlastic == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasGlass", property?.HasGlass == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasCurved", property?.HasCurved == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasLock", property?.HasLock == true ? 1 : 0);
                    command.Parameters.AddWithValue("@NormalLock", property?.NormalLock == true ? 1 : 0);
                    command.Parameters.AddWithValue("@FingerLock", property?.FingerLock == true ? 1 : 0);
                    command.Parameters.AddWithValue("@CodeLock", property?.CodeLock == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasPole", property?.HasPole == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasCloser", property?.HasCloser == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasDoorInDoor", property?.HasDoorInDoor == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasScreen", property?.HasScreen == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasAutoSwing", property?.HasAutoSwing == true ? 1 : 0);
                    command.Parameters.AddWithValue("@HasAutoSliding", property?.HasAutoSliding == true ? 1 : 0);

                    // 柱子相关属性
                    command.Parameters.AddWithValue("@PolePrice", property?.PolePrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PoleQty", property?.PoleQty ?? (object)DBNull.Value);

                    command.ExecuteNonQuery(); // 执行插入操作
                }
            }
        }


        // 更新“产品表”中的单价
        public void UpdateProductPrice(string material, string type, decimal newUnitPrice)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE 产品表 SET 单价 = @NewUnitPrice WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewUnitPrice", newUnitPrice); // 设置新的单价
                    command.Parameters.AddWithValue("@Material", material);        // 设置材料参数
                    command.Parameters.AddWithValue("@Type", type);                // 设置类型参数
                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }
        public void UpdateCustomizedProduct(string material, string type, string name, CustomizedProduct updatedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 更新数据
                string updateQuery = @"
        UPDATE 自定义产品表
        SET 
            单价 = @UnitPrice,
            名称 = @NewName,
            花样价格 = @DesignPrice,
            烤漆 = @IsPowder,
            金色 = @IsGold,
            古铜色 = @IsBronze,
            铁板 = @HasMetalSheet,
            胶板 = @HasPlastic,
            玻璃 = @HasGlass,
            弧形 = @HasCurved,
            有锁 = @HasLock,
            普通锁 = @NormalLock,
            指纹锁 = @FingerLock,
            密码锁 = @CodeLock,
            有柱子 = @HasPole,
            有闭门器 = @HasCloser,
            门中门 = @HasDoorInDoor,
            纱窗 = @HasScreen,
            电动双开 = @HasAutoSwing,
            电动推拉 = @HasAutoSliding,
            柱子价格 = @PolePrice,
            柱子数量 = @PoleQty
        WHERE 
            材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    // 设置查询条件的参数
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Name", name);

                    // 设置更新内容的参数
                    var property = updatedProduct.Property;
                    command.Parameters.AddWithValue("@UnitPrice", updatedProduct.UnitPrice);
                    command.Parameters.AddWithValue("@NewName", property.ProductName);
                    command.Parameters.AddWithValue("@DesignPrice", property.DesignPrice);

                    // 设置布尔属性的参数
                    command.Parameters.AddWithValue("@IsPowder", property.IsPowder ? 1 : 0);
                    command.Parameters.AddWithValue("@IsGold", property.IsGold ? 1 : 0);
                    command.Parameters.AddWithValue("@IsBronze", property.IsBronze ? 1 : 0);
                    command.Parameters.AddWithValue("@HasMetalSheet", property.HasMetalSheet ? 1 : 0);
                    command.Parameters.AddWithValue("@HasPlastic", property.HasPlastic ? 1 : 0);
                    command.Parameters.AddWithValue("@HasGlass", property.HasGlass ? 1 : 0);
                    command.Parameters.AddWithValue("@HasCurved", property.HasCurved ? 1 : 0);
                    command.Parameters.AddWithValue("@HasLock", property.HasLock ? 1 : 0);
                    command.Parameters.AddWithValue("@NormalLock", property.NormalLock ? 1 : 0);
                    command.Parameters.AddWithValue("@FingerLock", property.FingerLock ? 1 : 0);
                    command.Parameters.AddWithValue("@CodeLock", property.CodeLock ? 1 : 0);
                    command.Parameters.AddWithValue("@HasPole", property.HasPole ? 1 : 0);
                    command.Parameters.AddWithValue("@HasCloser", property.HasCloser ? 1 : 0);
                    command.Parameters.AddWithValue("@HasDoorInDoor", property.HasDoorInDoor ? 1 : 0);
                    command.Parameters.AddWithValue("@HasScreen", property.HasScreen ? 1 : 0);
                    command.Parameters.AddWithValue("@HasAutoSwing", property.HasAutoSwing ? 1 : 0);
                    command.Parameters.AddWithValue("@HasAutoSliding", property.HasAutoSliding ? 1 : 0);

                    // 设置柱子相关属性
                    command.Parameters.AddWithValue("@PolePrice", property.PolePrice);
                    command.Parameters.AddWithValue("@PoleQty", property.PoleQty);

                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }

        public void UpdateCalculatorProduct(CalculatorProduct queryProduct, CalculatorProduct updatedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 更新数据
                string updateQuery = @"
        UPDATE 计价表
        SET 
            材料 = @NewMaterial,
            类型 = @NewType,
            名称 = @NewName,
            单价 = @UnitPrice,
            长度或宽度 = @WidthOrLength,
            高度或深度 = @HeightOrDeepth,
            长度或宽度英尺 = @WidthOrLengthFeet,
            高度或深度英尺 = @HeightOrDeepthFeet,
            平方英尺 = @Sqft,
            花样价格 = @DesignPrice,
            花样数量 = @DesignQty,
            烤漆 = @IsPowder,
            金色 = @IsGold,
            古铜色 = @IsBronze,
            铁板 = @HasMetalSheet,
            胶板 = @HasPlastic,
            玻璃 = @HasGlass,
            弧形 = @HasCurved,
            有锁 = @HasLock,
            普通锁 = @NormalLock,
            指纹锁 = @FingerLock,
            密码锁 = @CodeLock,
            有柱子 = @HasPole,
            有闭门器 = @HasCloser,
            门中门 = @HasDoorInDoor,
            纱窗 = @HasScreen,
            电动双开 = @HasAutoSwing,
            电动推拉 = @HasAutoSliding,
            柱子价格 = @PolePrice,
            柱子数量 = @PoleQty,
            单个产品价格 = @SinglePrice,
            产品数量 = @Qty,
            总共价格 = @TotalPrice
        WHERE 
            材料 = @Material AND 类型 = @Type AND 名称 = @Name AND
            单价 = @OldUnitPrice AND
            长度或宽度 = @OldWidthOrLength AND
            高度或深度 = @OldHeightOrDeepth AND
            长度或宽度英尺 = @OldWidthOrLengthFeet AND
            高度或深度英尺 = @OldHeightOrDeepthFeet AND
            平方英尺 = @OldSqft AND
            花样价格 = @OldDesignPrice AND
            花样数量 = @OldDesignQty AND
            烤漆 = @OldIsPowder AND
            金色 = @OldIsGold AND
            古铜色 = @OldIsBronze AND
            铁板 = @OldHasMetalSheet AND
            胶板 = @OldHasPlastic AND
            玻璃 = @OldHasGlass AND
            弧形 = @OldHasCurved AND
            有锁 = @OldHasLock AND
            普通锁 = @OldNormalLock AND
            指纹锁 = @OldFingerLock AND
            密码锁 = @OldCodeLock AND
            有柱子 = @OldHasPole AND
            有闭门器 = @OldHasCloser AND
            门中门 = @OldHasDoorInDoor AND
            纱窗 = @OldHasScreen AND
            电动双开 = @OldHasAutoSwing AND
            电动推拉 = @OldHasAutoSliding AND
            柱子价格 = @OldPolePrice AND
            柱子数量 = @OldPoleQty AND
            单个产品价格 = @OldSinglePrice AND
            产品数量 = @OldQty AND
            总共价格 = @OldTotalPrice;";

                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    // 设置查询条件参数（旧数据）
                    command.Parameters.AddWithValue("@Material", queryProduct.Material);
                    command.Parameters.AddWithValue("@Type", queryProduct.Type);
                    command.Parameters.AddWithValue("@Name", queryProduct.Property.ProductName);
                    command.Parameters.AddWithValue("@OldUnitPrice", queryProduct.UnitPrice);
                    command.Parameters.AddWithValue("@OldWidthOrLength", queryProduct.WidthOrLength);
                    command.Parameters.AddWithValue("@OldHeightOrDeepth", queryProduct.HeightOrDeepth);
                    command.Parameters.AddWithValue("@OldWidthOrLengthFeet", queryProduct.WidthOrLengthFeet);
                    command.Parameters.AddWithValue("@OldHeightOrDeepthFeet", queryProduct.HeightOrDeepthFeet);
                    command.Parameters.AddWithValue("@OldSqft", queryProduct.Sqft);
                    command.Parameters.AddWithValue("@OldDesignPrice", queryProduct.Property.DesignPrice);
                    command.Parameters.AddWithValue("@OldDesignQty", queryProduct.DesignQty);
                    command.Parameters.AddWithValue("@OldIsPowder", queryProduct.Property.IsPowder);
                    command.Parameters.AddWithValue("@OldIsGold", queryProduct.Property.IsGold);
                    command.Parameters.AddWithValue("@OldIsBronze", queryProduct.Property.IsBronze);
                    command.Parameters.AddWithValue("@OldHasMetalSheet", queryProduct.Property.HasMetalSheet);
                    command.Parameters.AddWithValue("@OldHasPlastic", queryProduct.Property.HasPlastic);
                    command.Parameters.AddWithValue("@OldHasGlass", queryProduct.Property.HasGlass);
                    command.Parameters.AddWithValue("@OldHasCurved", queryProduct.Property.HasCurved);
                    command.Parameters.AddWithValue("@OldHasLock", queryProduct.Property.HasLock);
                    command.Parameters.AddWithValue("@OldNormalLock", queryProduct.Property.NormalLock);
                    command.Parameters.AddWithValue("@OldFingerLock", queryProduct.Property.FingerLock);
                    command.Parameters.AddWithValue("@OldCodeLock", queryProduct.Property.CodeLock);
                    command.Parameters.AddWithValue("@OldHasPole", queryProduct.Property.HasPole);
                    command.Parameters.AddWithValue("@OldHasCloser", queryProduct.Property.HasCloser);
                    command.Parameters.AddWithValue("@OldHasDoorInDoor", queryProduct.Property.HasDoorInDoor);
                    command.Parameters.AddWithValue("@OldHasScreen", queryProduct.Property.HasScreen);
                    command.Parameters.AddWithValue("@OldHasAutoSwing", queryProduct.Property.HasAutoSwing);
                    command.Parameters.AddWithValue("@OldHasAutoSliding", queryProduct.Property.HasAutoSliding);
                    command.Parameters.AddWithValue("@OldPolePrice", queryProduct.Property.PolePrice);
                    command.Parameters.AddWithValue("@OldPoleQty", queryProduct.Property.PoleQty);
                    command.Parameters.AddWithValue("@OldSinglePrice", queryProduct.SinglePrice);
                    command.Parameters.AddWithValue("@OldQty", queryProduct.Qty);
                    command.Parameters.AddWithValue("@OldTotalPrice", queryProduct.TotalPrice);

                    // 设置更新内容参数（新数据）
                    command.Parameters.AddWithValue("@NewMaterial", updatedProduct.Material);
                    command.Parameters.AddWithValue("@NewType", updatedProduct.Type);
                    command.Parameters.AddWithValue("@NewName", updatedProduct.Property.ProductName);
                    command.Parameters.AddWithValue("@UnitPrice", updatedProduct.UnitPrice);
                    command.Parameters.AddWithValue("@WidthOrLength", updatedProduct.WidthOrLength);
                    command.Parameters.AddWithValue("@HeightOrDeepth", updatedProduct.HeightOrDeepth);
                    command.Parameters.AddWithValue("@WidthOrLengthFeet", updatedProduct.WidthOrLengthFeet);
                    command.Parameters.AddWithValue("@HeightOrDeepthFeet", updatedProduct.HeightOrDeepthFeet);
                    command.Parameters.AddWithValue("@Sqft", updatedProduct.Sqft);
                    command.Parameters.AddWithValue("@DesignPrice", updatedProduct.Property.DesignPrice);
                    command.Parameters.AddWithValue("@DesignQty", updatedProduct.DesignQty);
                    command.Parameters.AddWithValue("@IsPowder", updatedProduct.Property.IsPowder);
                    command.Parameters.AddWithValue("@IsGold", updatedProduct.Property.IsGold);
                    command.Parameters.AddWithValue("@IsBronze", updatedProduct.Property.IsBronze);
                    command.Parameters.AddWithValue("@HasMetalSheet", updatedProduct.Property.HasMetalSheet);
                    command.Parameters.AddWithValue("@HasPlastic", updatedProduct.Property.HasPlastic);
                    command.Parameters.AddWithValue("@HasGlass", updatedProduct.Property.HasGlass);
                    command.Parameters.AddWithValue("@HasCurved", updatedProduct.Property.HasCurved);
                    command.Parameters.AddWithValue("@HasLock", updatedProduct.Property.HasLock);
                    command.Parameters.AddWithValue("@NormalLock", updatedProduct.Property.NormalLock);
                    command.Parameters.AddWithValue("@FingerLock", updatedProduct.Property.FingerLock);
                    command.Parameters.AddWithValue("@CodeLock", updatedProduct.Property.CodeLock);
                    command.Parameters.AddWithValue("@HasPole", updatedProduct.Property.HasPole);
                    command.Parameters.AddWithValue("@HasCloser", updatedProduct.Property.HasCloser);
                    command.Parameters.AddWithValue("@HasDoorInDoor", updatedProduct.Property.HasDoorInDoor);
                    command.Parameters.AddWithValue("@HasScreen", updatedProduct.Property.HasScreen);
                    command.Parameters.AddWithValue("@HasAutoSwing", updatedProduct.Property.HasAutoSwing);
                    command.Parameters.AddWithValue("@HasAutoSliding", updatedProduct.Property.HasAutoSliding);
                    command.Parameters.AddWithValue("@PolePrice", updatedProduct.Property.PolePrice);
                    command.Parameters.AddWithValue("@PoleQty", updatedProduct.Property.PoleQty);
                    command.Parameters.AddWithValue("@SinglePrice", updatedProduct.SinglePrice);
                    command.Parameters.AddWithValue("@Qty", updatedProduct.Qty);
                    command.Parameters.AddWithValue("@TotalPrice", updatedProduct.TotalPrice);

                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }


        // 根据条件删除“产品表”中的一行数据
        public void DeleteProduct(string material, string type)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", material); // 设置材料参数
                    command.Parameters.AddWithValue("@Type", type);         // 设置类型参数
                    command.ExecuteNonQuery(); // 执行删除操作
                }
            }
        }
        public void DeleteCustomizedProduct(CustomizedProduct customizedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = @"
            DELETE FROM 自定义产品表
            WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", customizedProduct.Material);
                    command.Parameters.AddWithValue("@Type", customizedProduct.Type);

                    command.Parameters.AddWithValue("@Name", customizedProduct.Property.ProductName);

                    command.ExecuteNonQuery(); // 执行删除操作
                }
            }
        }
        public void DeleteCustomizedProduct(string material, string type, string name)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = @"
            DELETE FROM 自定义产品表
            WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Name", name);

                    command.ExecuteNonQuery(); // 执行删除操作
                }
            }
        }
        public void DeleteCalculatorProduct(CalculatorProduct queryProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 删除数据
                string deleteQuery = @"
        DELETE FROM 计价表
        WHERE 
            材料 = @Material AND 类型 = @Type AND 名称 = @Name AND
            单价 = @UnitPrice AND
            长度或宽度 = @WidthOrLength AND
            高度或深度 = @HeightOrDeepth AND
            长度或宽度英尺 = @WidthOrLengthFeet AND
            高度或深度英尺 = @HeightOrDeepthFeet AND
            平方英尺 = @Sqft AND
            花样价格 = @DesignPrice AND
            花样数量 = @DesignQty AND
            烤漆 = @IsPowder AND
            金色 = @IsGold AND
            古铜色 = @IsBronze AND
            铁板 = @HasMetalSheet AND
            胶板 = @HasPlastic AND
            玻璃 = @HasGlass AND
            弧形 = @HasCurved AND
            有锁 = @HasLock AND
            普通锁 = @NormalLock AND
            指纹锁 = @FingerLock AND
            密码锁 = @CodeLock AND
            有柱子 = @HasPole AND
            有闭门器 = @HasCloser AND
            门中门 = @HasDoorInDoor AND
            纱窗 = @HasScreen AND
            电动双开 = @HasAutoSwing AND
            电动推拉 = @HasAutoSliding AND
            柱子价格 = @PolePrice AND
            柱子数量 = @PoleQty AND
            单个产品价格 = @SinglePrice AND
            产品数量 = @Qty AND
            总共价格 = @TotalPrice;";

                using (var command = new MySqlCommand(deleteQuery, connection))
                {
                    // 设置查询条件参数
                    command.Parameters.AddWithValue("@Material", queryProduct.Material);
                    command.Parameters.AddWithValue("@Type", queryProduct.Type);
                    command.Parameters.AddWithValue("@Name", queryProduct.Property.ProductName);
                    command.Parameters.AddWithValue("@UnitPrice", queryProduct.UnitPrice);
                    command.Parameters.AddWithValue("@WidthOrLength", queryProduct.WidthOrLength);
                    command.Parameters.AddWithValue("@HeightOrDeepth", queryProduct.HeightOrDeepth);
                    command.Parameters.AddWithValue("@WidthOrLengthFeet", queryProduct.WidthOrLengthFeet);
                    command.Parameters.AddWithValue("@HeightOrDeepthFeet", queryProduct.HeightOrDeepthFeet);
                    command.Parameters.AddWithValue("@Sqft", queryProduct.Sqft);
                    command.Parameters.AddWithValue("@DesignPrice", queryProduct.Property.DesignPrice);
                    command.Parameters.AddWithValue("@DesignQty", queryProduct.DesignQty);

                    // 设置布尔属性参数
                    command.Parameters.AddWithValue("@IsPowder", queryProduct.Property.IsPowder);
                    command.Parameters.AddWithValue("@IsGold", queryProduct.Property.IsGold);
                    command.Parameters.AddWithValue("@IsBronze", queryProduct.Property.IsBronze);
                    command.Parameters.AddWithValue("@HasMetalSheet", queryProduct.Property.HasMetalSheet);
                    command.Parameters.AddWithValue("@HasPlastic", queryProduct.Property.HasPlastic);
                    command.Parameters.AddWithValue("@HasGlass", queryProduct.Property.HasGlass);
                    command.Parameters.AddWithValue("@HasCurved", queryProduct.Property.HasCurved);
                    command.Parameters.AddWithValue("@HasLock", queryProduct.Property.HasLock);
                    command.Parameters.AddWithValue("@NormalLock", queryProduct.Property.NormalLock);
                    command.Parameters.AddWithValue("@FingerLock", queryProduct.Property.FingerLock);
                    command.Parameters.AddWithValue("@CodeLock", queryProduct.Property.CodeLock);
                    command.Parameters.AddWithValue("@HasPole", queryProduct.Property.HasPole);
                    command.Parameters.AddWithValue("@HasCloser", queryProduct.Property.HasCloser);
                    command.Parameters.AddWithValue("@HasDoorInDoor", queryProduct.Property.HasDoorInDoor);
                    command.Parameters.AddWithValue("@HasScreen", queryProduct.Property.HasScreen);
                    command.Parameters.AddWithValue("@HasAutoSwing", queryProduct.Property.HasAutoSwing);
                    command.Parameters.AddWithValue("@HasAutoSliding", queryProduct.Property.HasAutoSliding);

                    // 设置其他属性参数
                    command.Parameters.AddWithValue("@PolePrice", queryProduct.Property.PolePrice);
                    command.Parameters.AddWithValue("@PoleQty", queryProduct.Property.PoleQty);
                    command.Parameters.AddWithValue("@SinglePrice", queryProduct.SinglePrice);
                    command.Parameters.AddWithValue("@Qty", queryProduct.Qty);
                    command.Parameters.AddWithValue("@TotalPrice", queryProduct.TotalPrice);

                    command.ExecuteNonQuery(); // 执行删除操作
                }
            }
        }

        // 检查记录是否存在
        public bool RecordExists(string material, string type)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM 产品表 WHERE 材料 = @Material AND 类型 = @Type;";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);

                    decimal count = Convert.ToDecimal(command.ExecuteScalar());
                    return count > 0; // 返回是否存在
                }
            }
        }
        public bool DoesProductExist(string material, string type, string name)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            SELECT COUNT(1) 
            FROM 自定义产品表
            WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Name", name);

                    decimal count = Convert.ToDecimal(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public bool DoesProductExist(CustomizedProduct customizedProduct)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            SELECT COUNT(1) 
            FROM 自定义产品表
            WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", customizedProduct.Material);
                    command.Parameters.AddWithValue("@Type", customizedProduct.Type);
                    command.Parameters.AddWithValue("@Name", customizedProduct.Property.ProductName);

                    decimal count = Convert.ToDecimal(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool DoesCalculatorProductExist(CalculatorProduct product)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            SELECT COUNT(1) 
            FROM 计价表
            WHERE 材料 = @Material AND 类型 = @Type AND 名称 = @Name;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", product.Material);
                    command.Parameters.AddWithValue("@Type", product.Type);
                    command.Parameters.AddWithValue("@Name", product.Property.ProductName);

                    decimal count = Convert.ToDecimal(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public List<string> GetTableColumnNames(string tableName)
        {
            List<string> columnNames = new List<string>();
            string connectionString = _connectionString;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 查询 INFORMATION_SCHEMA.COLUMNS 获取列信息
                string query = @"
            SELECT COLUMN_NAME
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = @TableName;";

                using (var command = new MySqlCommand(query, connection))
                {
                    // 使用参数化查询以防止 SQL 注入
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 获取列名
                            columnNames.Add(reader["COLUMN_NAME"].ToString());
                        }
                    }
                }
            }

            return columnNames;
        }

        public string GetSingleValueAsString(string tableName, string columnName)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 构造查询语句
                string query = $"SELECT {columnName} FROM {tableName} LIMIT 1;";

                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty; // 如果为空，返回空字符串
                }
            }
        }
        public void UpdateSingleValue(string tableName, string columnName, string newValue)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 构造更新语句
                string updateQuery = $"UPDATE {tableName} SET {columnName} = @NewValue;";

                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    // 设置参数
                    command.Parameters.AddWithValue("@NewValue", newValue);
                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }

        public void InsertSingleValue(string tableName, string columnName, string value)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 构造插入语句
                string insertQuery = $"INSERT INTO {tableName} ({columnName}) VALUES (@Value);";

                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    // 设置参数
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery(); // 执行插入操作
                }
            }
        }
        public void UpdateSetPriceTable(
    decimal powder, decimal gold, decimal bronze, decimal metalSheet, decimal plastic, decimal glass,
    decimal curved, decimal normalLock, decimal fingerLock, decimal codeLock,decimal closer,
    decimal doorInDoor, decimal screen, decimal autoSwing, decimal autoSliding)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // 构造更新语句
                string updateQuery = @"
        UPDATE 设置单价表
        SET 
            烤漆 = @Powder,
            金色 = @Gold,
            古铜色 = @Bronze,
            铁板 = @MetalSheet,
            胶板 = @Plastic,
            玻璃 = @Glass,
            弧形 = @Curved,
            普通锁 = @NormalLock,
            指纹锁 = @FingerLock,
            密码锁 = @CodeLock,
            闭门器 = @Closer,

            门中门 = @DoorInDoor,
            纱窗 = @Screen,
            电动双开 = @AutoSwing,
            电动推拉 = @AutoSliding;";

                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    // 设置所有参数的值
                    command.Parameters.AddWithValue("@Powder", powder);
                    command.Parameters.AddWithValue("@Gold", gold);
                    command.Parameters.AddWithValue("@Bronze", bronze);
                    command.Parameters.AddWithValue("@MetalSheet", metalSheet);
                    command.Parameters.AddWithValue("@Plastic", plastic);
                    command.Parameters.AddWithValue("@Glass", glass);
                    command.Parameters.AddWithValue("@Curved", curved);
                    command.Parameters.AddWithValue("@NormalLock", normalLock);
                    command.Parameters.AddWithValue("@FingerLock", fingerLock);
                    command.Parameters.AddWithValue("@CodeLock", codeLock);

                    command.Parameters.AddWithValue("@Closer", closer);
                    command.Parameters.AddWithValue("@DoorInDoor", doorInDoor);
                    command.Parameters.AddWithValue("@Screen", screen);
                    command.Parameters.AddWithValue("@AutoSwing", autoSwing);
                    command.Parameters.AddWithValue("@AutoSliding", autoSliding);

                    command.ExecuteNonQuery(); // 执行更新操作
                }
            }
        }




    }


}