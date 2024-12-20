using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.TablesRes
{
    public class ActiveDetail
    {
        public int ID_details { get; set; } // Внешний ключ
        public decimal Sell { get; set; }
        public string Detail_name { get; set; }
    }
}
