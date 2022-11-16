using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBClass;

namespace Game15
{
    public partial class TableWinners : Form
    {
        
        public TableWinners()
        {
            InitializeComponent();
            
        }

        private void TableWinners_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void TableWinners_Load(object sender, EventArgs e)
        {
            DBClass.ApplicationContext db = new DBClass.ApplicationContext();

            db.Winners.Load();
            System.Collections.ObjectModel.ObservableCollection<DBWinners>
            // и устанавливаем данные в качестве контекста
            DataContextCurrentGame = db.Winners.Local.ToObservableCollection();

            var kk = db.DBCurrentGame.ToList();

            dataGridView1.DataSource = kk;









        }
    }
}
