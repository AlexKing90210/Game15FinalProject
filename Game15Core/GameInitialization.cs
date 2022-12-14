namespace Game15Core
{
    public class GameInitialization
    {
        // Основной двумерный массив используемый в игре
        private int[,] map;

        // Размер стороны игрового поля
        private int size;

        // Массив номеров от 1 до size^2
        private int[] positions;

        // Позиция нуля по координате X в массиве Map
        private int zero_X;

        // Позиция нуля по координтае Y в массиве Map
        private int zero_Y;

        public int[,] Map
        {
            get { return map; }
            set { map = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int[] Positions
        {
            get { return positions; }
            set { positions = value; }
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


        // Метод, заполняющий массив значений элементами от 0 до 16
        private void PositionsBuilder()
        {
            int size = this.Size;
            this.positions = new int[size * size];
            for (int pos = 0; pos < size * size; pos++)
            {
                this.Positions[pos] = pos;
            }
        }

        // Метод для перемешивания чисел в массиве значений
        private void Shuffle()
        {
            int[] arr = this.Positions;
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var rndInd = rnd.Next(0, arr.Count());
                var rndInd2 = rnd.Next(0, arr.Count());
                var temp = arr[rndInd];
                arr[rndInd] = arr[rndInd2];
                arr[rndInd2] = temp;
            }

            // Проверка на комбинации, при которых игра не разрешима
            if ((arr[arr.Length - 2] == 15 && arr[arr.Length - 3] == 14)
                || (arr[arr.Length - 2] == 14 && arr[arr.Length - 3] == 15))
            {
                this.Shuffle();
            }
        }

        // Метод инициализирующий игровое поле и связи между полями класса
        public void InitMap()
        {
            int size = this.Size;
            this.PositionsBuilder();
            this.Shuffle();
            this.Map = new int[size, size];
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    this.Map[x, y] = this.Positions[y * size + x];
                    if (this.Positions[y * size + x] == 0)
                    {
                        this.Zero_X = x;
                        this.Zero_Y = y;
                    }
                }
        }

        // Метод для получения текущего элемента массива в зависимости от кнопки на форме
        public int GetNumber(int position)
        {
            int x, y;
            x = position / this.Size;
            y = position % this.Size;

            return this.Map[x, y];
        }
    }
}
