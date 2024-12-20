using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.TablesRes
{
    public class Sell
    {
        public int ID_details { get; set; } // Внешний ключ
        public DateTime Sell_date { get; set; }
        public string Sell_place { get; set; }
        public TimeSpan? Time_sell { get; set; } // Nullable тип для Time_sell
    }
}
