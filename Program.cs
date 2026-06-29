using System.IO.Pipes;
using System.Numerics;

namespace GrTypuRouglike;

public class Program
{
    public static void Main()
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
        Map map = new Map();
        map.LoadFromFile("level1.txt");
        
        Item iten = new Item('☺', new Vector2(1, 2), map);
        //^^ wydaje mi się że Program to nie jest dobre miejsce na rozrzucanie itemków po mapie
        // !! dobrym będzie stworzyć jakąś funkcję w Map, albo dictionary MappItemToss
        //który będzie przypisywał nazwęmapy, a potem grupę itemów które należy po niej losowo rozrzucić


        bool isPlaying = true;
        //POZYCJA STARTOWA - GRACZ
        Vector2 startingPosition = new Vector2(4, 2);
        Character hero = new Player('@', startingPosition, map, directions);
        startingPosition.X = 1;
        startingPosition.Y = 1;

        Character anotherHero = new Npc('$', startingPosition, map);
        List<Character> characters = [hero, anotherHero]; //<lista postaci na poziomie

        map.Display(); //<< no tak, trza wyświetlić mapę xD

        while (isPlaying)
        {
            foreach (Character character in characters)
            {
                isPlaying = character.TakeTurn(map);
            }
        }// hmm, takie proste, a takie trudne do zrozumienia to TakeTurn
        
        Console.WriteLine("Goodbye!"); //<<?????? a co to?
    }

    

}