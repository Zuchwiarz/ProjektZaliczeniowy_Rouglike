using System.IO.Pipes;
using System.Numerics;
using System.Timers;

namespace GrTypuRouglike;

public class Program
{
    public static int playTime;
    public static void Main()
    {
        //======TIMER=======
        System.Timers.Timer timer = new System.Timers.Timer();   
        timer.Interval = 1000;
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;

        
        
        
        //==================
        Console.CursorVisible = false;
        //STEROWANIE - przypisanie vektorów do klawiszy
        Dictionary<ConsoleKey, Vector2> directions = new Dictionary<ConsoleKey, Vector2>();
        directions[ConsoleKey.A] = new Vector2(-1, 0);
        directions[ConsoleKey.D] = new Vector2(1, 0);
        directions[ConsoleKey.W] = new Vector2(0, -1);
        directions[ConsoleKey.S] = new Vector2(0, 1);
        
        Map map = new Map();
        LvlManager lvlManager = new LvlManager(map);
        lvlManager.LoadLvl("level1");
        
         //tworzymy bohatera (nie co lvl, chcemy tego samego przez całą grę więć tworzymy raz)
         Vector2 startingPosition = new Vector2(4, 2); //<< spawn point na pierwszym lvlu
         Character hero = new Player('@', startingPosition, map, directions); //<< oto on
         
         bool isPlaying = true;
         
        
         List<Character> characters = [hero];

        while (isPlaying)
        {
            // switch za każdy level1
            foreach (Character character in characters)
            {
                isPlaying = character.TakeTurn(map, characters);
                
                if (!isPlaying)
                {
                    break;
                }
            }

            foreach (Character character in lvlManager.NPCs)
            {
                isPlaying = character.TakeTurn(map, characters); // pilnoać ile npc
            }


            
        }// hmm, takie proste, a takie trudne do zrozumienia to TakeTurn
        
        Console.WriteLine("Goodbye!"); //<<?????? a co to? 
    }
    
    
    //PODSUMOWANIE
    /*
     * <uzupełnić>
     */

    

    private static void OnTimedEvent(object sender, EventArgs eventArgs)
    {
        //dodaj sekundę
        playTime += 1;
        
    }
}
