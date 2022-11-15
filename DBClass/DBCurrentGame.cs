using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClass
{
    public class DBCurrentGame
    {
        public int Id { get; set; }
        public int GameSize { get; set; }
        public int CountMove { get; set; }
        public string Digits { get; set; }
    }
}
