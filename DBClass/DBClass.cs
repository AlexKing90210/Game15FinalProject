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
            string curFile = "TestDB.db";
            Console.WriteLine(curFile);
            if (!File.Exists(curFile))
            {
                SQLiteConnection.CreateFile(curFile);
            }
        }

        static void Main()
        {
            DBClass dbClass = new DBClass();
            dbClass.CreateDb();
        }
    };
}