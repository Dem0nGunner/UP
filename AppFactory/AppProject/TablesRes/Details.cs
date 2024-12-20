using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.TablesRes
{
    public class Details
    {
        public int ID { get; set; } // Первичный ключ
        public DateTime Prod_date { get; set; }
        public int Prod_count { get; set; }
        public string Serial_num { get; set; }
    }
}
