using Game15Core;


namespace Game15
{
    public partial class GameForm : Form
    {
        // Инициализация подготовки игры
        GameInitialization gameInit = new GameInitialization();
        // Инициализация самой игры
        GameLogic game = new GameLogic();
        
        public GameForm()
        {
            InitializeComponent();
            gameInit.Size = 4;
        }

        // Инициализация новой игры
        private void GameStart()
        {
            gameInit.InitMap();
            game.Size = gameInit.Size;
            game.Map = gameInit.Map;
            game.Zero_X = gameInit.Zero_X;
            game.Zero_Y = gameInit.Zero_Y;
            game.GameEnd = false;
        }

        // Метод, который запускает новую игру, каждый раз при нажатии на клавишу "Новая игра"
        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart();
            refresh();
        }

        // Метод, который запускает новую игру, каждый раз при запуске программы
        private void GameForm_Load(object sender, EventArgs e)
        {
            GameStart();
            refresh();
        }

        // Метод, отвечающий за перерисовку клавиш при перемещении
        private void button0_Click(object sender, EventArgs e)
        {
            int position = 0;
            position = int.Parse((string)((Button)sender).Tag);
            game.shiftMove(position);
            refresh();
            
            // Проверка условия окончания игры
            if (game.GameEnd == true)
            {
                if(MessageBox.Show("Вы победили!") == DialogResult.OK)
                {
                    GameStart();
                    refresh();
                }
            }

        }

        // Метод, который определяет нажатую кнопку
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

        // Метод, отвечающий за перерисовку номеров на кнопках игрового поля
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