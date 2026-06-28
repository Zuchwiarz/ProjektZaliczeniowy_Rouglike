using System.Numerics;

namespace GrTypuRouglike;

public class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        //STEROWANIE - przypisanie vektorów do klawiszy
        Dictionary<ConsoleKey, Vector2> directions = new Dictionary<ConsoleKey, Vector2>();
        directions[ConsoleKey.A] = new Vector2(-1, 0);
        directions[ConsoleKey.D] = new Vector2(1, 0);
        directions[ConsoleKey.W] = new Vector2(0, 1);
        directions[ConsoleKey.S] = new Vector2(0, -1);
        
        //WCZYTYWANIE MAPY
            // 1. najpierw stworzymy CEll
            // 2. A potem Map()
        //Map map = new Map();
        //mapLoadFromFile("level1.txt");
    }
}