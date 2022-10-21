using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game15Core;


namespace Game15
{
    public partial class GameForm : Form
    {
        GameInitialization gameInit = new GameInitialization();
        

        GameLogic game = new GameLogic();
        
        public GameForm()
        {
            InitializeComponent();

            gameInit.Size = 4;
            
        }

        private void GameStart()
        {
            // Инициализация новой игры
            gameInit.InitMap();
            game.Size = gameInit.Size;
            game.Map = gameInit.Map;
            game.Zero_X = gameInit.Zero_X;
            game.Zero_Y = gameInit.Zero_Y;
            game.GameEnd = false;
        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart();
            refresh();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameStart();
            refresh();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            int position = 0;
            position = int.Parse((string)((Button)sender).Tag);
            game.shiftMove(position);
            refresh();
                
            if (game.GameEnd == true)
            {
                //MessageBox.Show("Вы победили!");
                if(MessageBox.Show("Вы победили!") == DialogResult.OK)
                {
                    GameStart();
                    refresh();
                }
            }

        }


        private Button button(int position)
        {
            switch(position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
        private void refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int func = gameInit.GetNumber(position);
                button(position).Text = func.ToString();
                button(position).Visible = (func > 0);
            }
        }

        
    }
}