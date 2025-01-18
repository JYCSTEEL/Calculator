using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    public class Calculator:Controls
    {
       
        public string ProductType { get => mainView.ProductType; set => mainView.ProductType = value; }
        public int UnitPrice { get => mainView.UnitPrice; set => mainView.UnitPrice = value; }
        public int LengthWidthInch { get => mainView.LengthWidthInch; set => mainView.LengthWidthInch = value; }
        public int LengthWidthFeet { get => mainView.LengthWidthFeet; set => mainView.LengthWidthFeet = value; }
        public int HeightDeepthInch { get => mainView.HeightDeepthInch; set => mainView.HeightDeepthInch = value; }
        public int HeightDeepthFeet { get => mainView.HeightDeepthFeet; set => mainView.HeightDeepthFeet = value; }
        public int Sqft { get => mainView.Sqft; set => mainView.Sqft = value; }
        public int PoleQty { get => mainView.PoleQty; set => mainView.PoleQty = value   ; }
        public int DesignUnitPrice { get => mainView.DesignUnitPrice; set => mainView.DesignUnitPrice = value           ; }
        public int PredictDesignQty { get => mainView.PredictDesignQty; set => mainView.PredictDesignQty = value; }
        public bool HasPole { get => mainView.HasPole; set => mainView.HasPole = value; }
        public bool IsPowderCoating { get => mainView.IsPowderCoating; set => mainView.IsPowderCoating = value; }
        public bool IsBronze { get => mainView.IsBronze; set => mainView.IsBronze = value; }
        public bool IsGold { get => mainView.IsGold; set => mainView.IsGold = value; }
        public bool HasGlass { get => mainView.HasGlass; set => mainView.HasGlass = value; }
        public bool HasScreen { get => mainView.HasScreen; set => mainView.HasScreen = value; }
        public bool HasPlastic { get => mainView.HasPlastic; set => mainView.HasPlastic = value; }
        public bool HasMetalSheet { get => mainView.HasMetalSheet; set => mainView.HasMetalSheet = value; }
        public bool HasCurve { get => mainView.HasCurve; set => mainView.HasCurve = value; }
        public bool HasCloser { get => mainView.HasCloser; set => mainView.HasCloser = value; }

        public bool HasLock { get => mainView.HasLock; set => mainView.HasLock = value; }
        public bool IsNormalLock { get => mainView.IsNormalLock; set => mainView.IsNormalLock = value; }

        public bool IsCodeLock { get => mainView.IsCodeLock; set => mainView.IsCodeLock = value; }

        public bool IsFingerPrintLock { get => mainView.IsFingerPrintLock; set => mainView.IsFingerPrintLock = value; }
        // 静态字段，存储单例实例
        private static readonly Calculator _instance = new Calculator();

   

        // 私有构造函数，防止外部实例化
        private Calculator()
        {
            // 初始化逻辑（如果需要）

        }

        // 静态属性，用于获取单例实例
        public static Calculator Instance
        {
            get
            {
                return _instance;
            }
        }


    }

}
