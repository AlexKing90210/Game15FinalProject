using Game15Core;
using DBClass;
using Microsoft.EntityFrameworkCore;


namespace Game15
{
    public partial class GameForm4 : Form
    {
        // Инициализация подготовки игры
        GameInitialization gameInit = new GameInitialization();
        
        // Инициализация самой игры
        GameLogic game = new GameLogic();

        DBClass.ApplicationContext db = new DBClass.ApplicationContext();

        public GameForm4()
        {
            InitializeComponent();
            gameInit.Size = 4;
        }

        // Инициализация самой игры
        public void GameStart()
        {
            gameInit.InitMap();
            game.Size = gameInit.Size;
            game.Map = gameInit.Map;
            game.Zero_X = gameInit.Zero_X;
            game.Zero_Y = gameInit.Zero_Y;
            game.GameEnd = false;
            game.CountShift = 0;
        }

        public void GameResume()
        {
            // Инициализация игры
            
            //gameInit.InitMap();
            db.DBCurrentGame.Load();
            System.Collections.ObjectModel.ObservableCollection<DBCurrentGame>
            // и устанавливаем данные в качестве контекста
            DataContextCurrentGame = db.DBCurrentGame.Local.ToObservableCollection();
            int name = (from m in db.DBCurrentGame select m.Id).ToList().Last();
            var curGame = db.DBCurrentGame.Find(name);
            game.Size = curGame.GameSize;


            // Взять массив из базы и преобразовать его в массив для игры
            string[] stringDb = curGame.Digits.Split('$');
            int[] Positions = new int[curGame.GameSize * curGame.GameSize];
            int[,] map = new int[curGame.GameSize, curGame.GameSize];
            int zero_x = 0;
            int zero_y = 0;

            for(int x = 0; x< stringDb.Length; x++)
            {
                Positions[x] = Convert.ToInt32(stringDb[x].ToString());
            }

            // Заполнение массива игры
            for (int x = 0; x < curGame.GameSize; x++)
                for (int y = 0; y < curGame.GameSize; y++)
                {
                    map[x, y] = Positions[x * curGame.GameSize + y];
                    if (Positions[x * curGame.GameSize + y] == 0)
                    {
                        zero_x = x;
                        zero_y = y;
                    }
                }

            // Начальная инициализация
            gameInit.Map = map;
            gameInit.Positions = Positions;
            gameInit.Zero_X = zero_x;
            gameInit.Zero_Y = zero_y;

            // Инициализация игры
            game.Map = map;
            game.Zero_X = zero_x;
            game.Zero_Y = zero_y;
            game.GameEnd = false;
            game.CountShift = curGame.CountMove;

            label2.Text = game.CountShift.ToString();
        }

        // Метод, который запускает новую игру, каждый раз при нажатии на клавишу "Новая игра"
        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart();
            refresh();
        }

        // Метод, который запускает новую игру, каждый раз при запуске программы
        private void GameForm4_Load(object sender, EventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Winners.Load();
            // db.DBCurrentGame.Load();
            System.Collections.ObjectModel.ObservableCollection<Winners>
            // и устанавливаем данные в качестве контекста
            DataContextWinners = db.Winners.Local.ToObservableCollection();

            //GameStart();
            refresh();
        }

        // Метод, отвечающий за перерисовку клавиш при перемещении
        private void button0_Click(object sender, EventArgs e)
        {
            int position = 0;
            position = int.Parse((string)((Button)sender).Tag);
            game.shiftMove(position);
            label2.Text = game.CountShift.ToString();
            refresh();

            // Проверка условия окончания игры
            if (game.GameEnd == true)
            {
                if (MessageBox.Show("Вы победили!") == DialogResult.OK)
                {
                    GameStart();
                    refresh();
                }
            }

        }

        // Метод, который определяет нажатую кнопку
        private Button button(int position)
        {
            switch (position)
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

        private void GameForm4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            db.DBCurrentGame.Load();
            System.Collections.ObjectModel.ObservableCollection<DBCurrentGame>
            // и устанавливаем данные в качестве контекста
            DataContextCurrentGame = db.DBCurrentGame.Local.ToObservableCollection();

            // Ищем объект сохранения
            int name = (from m in db.DBCurrentGame select m.Id).ToList().Last();
            var curGame = db.DBCurrentGame.Find(name);
            string a = curGame.Digits;
            int[] Pos = new int[game.Size * game.Size];

            for(int x=0; x<game.Size; x++)
            {
                for(int y=0; y<game.Size; y++)
                {
                    Pos[x * game.Size + y] = game.Map[x, y]; 
                };
            }

            string MasPos = string.Join('$', Pos);

            // Сохранение результатов в БД
            curGame.Digits = MasPos;
            curGame.CountMove = game.CountShift;

            db.SaveChanges();

            Application.Exit();

        }
    }
}