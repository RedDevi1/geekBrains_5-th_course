using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross_zero
{
    public class Game
    {
        // 3. Определяем размеры массива
        static int SIZE_X = 4;
        static int SIZE_Y = 4;

        // 1. Создаем двумерный массив
        static char[,] field = new char[SIZE_Y, SIZE_X];

        // 2. Обозначаем кто будет ходить какими фишками
        public static char PLAYER_DOT = 'X';
        public static char AI_DOT = '0';
        static char EMPTY_DOT = '.';

        // 12. Создаем рандом
        static Random rand = new Random();

        // 4. Заполняем на массив
        public static void initField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }


        // 5. Выводим на массив на печать
        public static void printField()
        {
            //6. украшаем картинку
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            //6. украшаем картинку
            Console.WriteLine("-------");
        }

        // 10. Проверяем возможен ли ход
        public static bool isCellValid(int y, int x)
        {
            // если вываливаемся за пределы возвращаем false
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }
            // если не путое поле тоже false
            return (field[y, x] == EMPTY_DOT);
        }

        // 7. Метод который устанавливает символ
        public static void setSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        // 9. Ход игрока
        public static void playerStep()
        {
            // 11. с проверкой
            int x;
            int y;
            do
            {
                Console.WriteLine($"Введите координаты: X Y (1-{SIZE_X})");
                x = Int32.Parse(Console.ReadLine()) - 1;
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!isCellValid(y, x));
            setSym(y, x, PLAYER_DOT);
        }


        // 13. Ход ПК
        public static void aiStep()
        {
            int x;
            int y;
            var tuple = checkBlockPlayer();
            if (tuple.isNeedToBlock)
            {
                x = tuple.x;
                y = tuple.y;
            }
            else
            {
                do
                {
                    x = rand.Next(0, SIZE_X);
                    y = rand.Next(0, SIZE_Y);
                } while (!isCellValid(y, x));
            }           
            setSym(y, x, AI_DOT);
        }

        // 14. Проверка победы
        public static bool checkWin(char sym)
        {
            var isWin = false;
            for (var i = 0; i < SIZE_Y; i++)
            {
                var flag = 0;
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] != sym)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    isWin = true;
                    return isWin;
                }                   
            }

            for (var i = 0; i < SIZE_Y; i++)
            {
                var flag = 0;
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (field[j, i] != sym)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    isWin = true;
                    return isWin;
                }
            }

            for (var i = 0; i < SIZE_Y; i++)
            {
                var flag = 0;
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (i != j)
                        continue;
                    else if (field[i, j] != sym)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0 && i == SIZE_Y - 1)
                {
                    isWin = true;
                    return isWin;
                }
                if (flag == 1)
                    break;               
            }

            for (var i = 0; i < SIZE_X; i++)
            {
                var flag = 0;
                if (field[i, SIZE_X - i - 1] != sym)
                {
                    flag = 1;
                    break;
                }
                if (flag == 0 && i == SIZE_X - 1)
                {
                    isWin = true;
                    return isWin;
                }
            }
            return isWin;
        }

        // 16. Проверка полное ли поле? возможно ли ходить?
        public static bool isFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // 17. Проверка на необходимость блокировки хода игрока и, в случае необходимости, возврат координат

        public static (bool isNeedToBlock, int x, int y) checkBlockPlayer()
        {
            var result = (isNeedToBlock: false, x: 0, y: 0);
            var cnt = 0;
            for (var i = 0; i < SIZE_Y; i++)
            {               
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == PLAYER_DOT)
                    {
                        cnt++;
                    }
                    else if (field[i, j] == EMPTY_DOT)
                    {
                        result.x = j;
                        result.y = i;
                    }
                }
                if (cnt == SIZE_X - 1)
                {
                    result.isNeedToBlock = true;
                    return result;
                }
                cnt = 0;
            }

            for (var i = 0; i < SIZE_Y; i++)
            {               
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (field[j, i] == PLAYER_DOT)
                    {
                        cnt++;
                    }
                    else if (field[i, j] == EMPTY_DOT)
                    {
                        result.x = i;
                        result.y = j;
                    }
                }
                if (cnt == SIZE_Y - 1)
                {
                    result.isNeedToBlock = true;
                    return result;
                }
                cnt = 0;
            }

            for (var i = 0; i < SIZE_Y; i++)
            {
                for (var j = 0; j < SIZE_X; j++)
                {
                    if (i != j)
                        continue;
                    else if (field[i, j] == PLAYER_DOT)
                    {
                        cnt++;
                    }
                    else if (field[i, j] == EMPTY_DOT)
                    {
                        result.x = j;
                        result.y = i;
                    }
                }
                if (cnt == SIZE_Y - 1)
                {
                    result.isNeedToBlock = true;
                    return result;
                }
            }
            cnt = 0;

            for (var i = 0; i < SIZE_X; i++)
            {
                if (field[i, SIZE_X - i - 1] == PLAYER_DOT)
                {
                    cnt++;
                }
                else if (field[i, SIZE_X - i - 1] == EMPTY_DOT)
                {
                    result.x = SIZE_X - i - 1;
                    result.y = i;
                }
                if (i == SIZE_X - 1 && cnt == SIZE_X - 1)
                {
                    result.isNeedToBlock = true;
                    return result;
                }
            }
            return result;
        }
    }
}
