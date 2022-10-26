namespace Game15Core
{
    public class GameLogic
    {
        // Основной двумерный массив используемый в игре
        private int[,] map;

        // Позиция нуля по координате X в массиве Map
        private int zero_X;

        // Позиция нуля по координате Y в массиве Map
        private int zero_Y;

        // Признак окончания игры
        private bool gameEnd;

        // Размер стороны игрового поля
        private int size;

        public int[,] Map
        {
            get { return map; }
            set { map = value; }
        }

        public int Zero_X
        {
            get { return zero_X; }
            set { zero_X = value; }
        }

        public int Zero_Y
        {
            get { return zero_Y; }
            set { zero_Y = value; }
        }

        public bool GameEnd
        {
            get { return gameEnd; }
            set { gameEnd = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        // Метод преобразующий позицию в координаты на игровом поле
        private int[] PositionToCoord(int position)
        {
            int x, y;
            x = position / this.Size;
            y = position % this.Size;

            int[] result = new int[2];
            result[0] = x;
            result[1] = y;

            return result;
        }

        // Метод, который позволяет совершать ход
        public void shiftMove(int position)
        {
            // Получим координаты выбранной позиции
            int[] result = PositionToCoord(position);
            int result_X = result[0];
            int result_Y = result[1];

            // Проверка координат выбранной позиции
            if ((Math.Abs(this.Zero_X - result_X) + Math.Abs(this.Zero_Y - result_Y)) != 1)
            {
                // Не двигаем ничего
                return;
            }

            // Смена координат
            this.Map[this.Zero_X, this.Zero_Y] = this.Map[result_X, result_Y];
            this.Map[result_X, result_Y] = 0;
            this.Zero_X = result_X;
            this.Zero_Y = result_Y;
            this.IsWin();

        }

        // Метод для определения признака победы
        private void IsWin()
        {
            int[] value = new int[this.Size * this.Size];
            int[] testCase = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0};

            // Получим массив значений на каждом ходе
            for(int x = 0; x < this.Size; x++)
                for(int y=0; y < this.Size; y++)
                {
                    if((this.Map[x, y] == testCase[y * this.Size + x]))
                    {
                        value[y * this.Size + x] = 0;
                    }
                    else 
                    {
                        value[y * this.Size + x] = 1;
                        break;
                    }
                }

            // Блок проверок полученного массива истинности
            if(value.Sum() == 0)
            {
                this.GameEnd = true;
            }
        }
    }
}
