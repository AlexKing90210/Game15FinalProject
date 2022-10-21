using Xunit;
using Game15Core;

namespace Game15Tests
{
    public class GameInit_Test
    {
        [Fact]
        public void GemeInitilizationTest()
        {
            // Arrange
            int x = 1;
            int y = 2;

            // Act
            GameInitialization gameInit = new GameInitialization();
            gameInit.Size = 4;
            gameInit.InitMap();
            int[] pos = gameInit.Positions;
            int[,] actualMap = gameInit.Map;
            int expected = pos[y * gameInit.Size + x];
            int actual = actualMap[x, y];


            // Assert
            Assert.Equal(expected, actual); // Проверка, что в массиве по определенным индексом содержится корректное значение
        }

        [Fact]
        public void GemeInitilizationGetNumberTest()
        {
            // Arrange
            int x = 0;
            int y = 0;

            // Act
            GameInitialization gameInit = new GameInitialization();
            gameInit.Size = 4;
            gameInit.InitMap();
            int[] pos = gameInit.Positions;
            int[,] actualMap = gameInit.Map;
            int expected = gameInit.GetNumber(0);
            int actual = actualMap[x, y];


            // Assert
            Assert.Equal(expected, actual); // Проверка, что из массива по определенной позиции возвращается верное число, записанное в массив
        }
    }
}