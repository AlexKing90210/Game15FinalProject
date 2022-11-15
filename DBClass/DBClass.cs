using System;
using System.Data.SQLite;

namespace DBClass
{
    public class DBClass
    {
        public void Test()
        {
            Console.WriteLine("Hello DB");
        }

        public void CreateDb()
        {
            if (!File.Exists(@"TestDB.db"))
            {
                SQLiteConnection.CreateFile(@"TestDB.db"); 
            }           
        }
    };
}