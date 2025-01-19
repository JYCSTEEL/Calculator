using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    public class ProductProperty
    {
        public string Name { get; set; }
        public int WidthOrLength { get; set; }
        public int HeightOrDeepth { get; set; }

        public int WidthOrLengthFeet { get; set; }
        public int HeightOrDeepthFeet { get; set; }

        public int Sqft { get; set; }

        public int DesignPrice { get; set; }

        public int DesignQty { get; set; }


        public bool IsPowder { get; set; }

        public bool IsGold { get; set; }
        public bool IsBronze { get; set; }

        public bool HasMetalSheet { get; set; }
        public bool HasPlastic { get; set; }
        public bool HasGlass { get; set; }
        public bool HasCurved { get; set; }
        public bool HasLock { get; set; }
        public bool NormalLock { get; set; }

        public bool FingerLock { get; set; }

        public bool CodeLock { get; set; }
        public bool HasPole { get; set; }
        public bool HasCloser { get; set; }
        public bool HasDoorInDoor { get; set; }
        public bool HasScreen { get; set; }
        public bool HasAutoSwing { get; set; }
        public bool HasAutoSliding { get; set; }

        public int PolePrice { get; set; }
        public int PoleQty { get; set; }



    }
}
