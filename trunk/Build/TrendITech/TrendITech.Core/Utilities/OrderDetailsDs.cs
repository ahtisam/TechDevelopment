using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Utilities
{
    [Serializable]
    public class OrderDetailsDs
    {
        public int ID { get; set; }
        public int DbID { get; set; }
        public string ImgUrl { get; set; }
        public string ModelVal { get; set; }
        public string ItemCost { get; set; }
        public string ItemQty { get; set; }
        public string ItemComment { get; set; }
        public bool IsActive { get; set; }
    }
}
