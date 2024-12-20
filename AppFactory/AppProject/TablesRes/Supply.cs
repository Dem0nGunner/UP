using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.TablesRes
{
    public class Supply
    {
        public int ID_details { get; set; } // Внешний ключ
        public DateTime Real_date { get; set; }
        public string Target_pl { get; set; }
        public string Out_pl { get; set; }
    }
}
