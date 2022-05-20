using Cross_zero;


// 1 - 1 иницируем и выводим на печать
Game.initField();
Game.printField();
// 1 - 1 иницируем и выводим на печать
// 15 Основной ход программы
while (true)
{
    Game.playerStep();
    Game.printField();
    if (Game.checkWin(Game.PLAYER_DOT))
    {
        Console.WriteLine("Player WIN!");
        break;
    }
    if (Game.isFieldFull())
    {
        Console.WriteLine("DRAW");
        break;
    }

    Game.aiStep();
    Game.printField();
    if (Game.checkWin(Game.AI_DOT))
    {
        Console.WriteLine("Win SkyNet!");
        break;
    }
    if (Game.isFieldFull())
    {
        Console.WriteLine("DRAW");
        break;
    }
}


