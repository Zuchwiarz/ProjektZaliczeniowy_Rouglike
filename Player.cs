using System.Numerics;

namespace GrTypuRouglike;

public class Player : Character
{
    public bool gameEND;
    private int currentLVLnumber = 1;
     LvlManager _lvlManager;
     
     
    
    
    private readonly Dictionary<ConsoleKey, Vector2> _inputMap;

    public Player(char avatar, Vector2 startingPosition, Map map, Dictionary<ConsoleKey, Vector2> inputMap, LvlManager lvlManager ) : base(avatar, startingPosition, map)
    {
        _inputMap = inputMap;
        // aha? po prostu przypisujemy graczowi sterowanie?
        _lvlManager = lvlManager;
        imHero = true;
        life = 3;
    }

    // public void lifeLoss()
    // {
    //     life -= 1;
    // }
    

   

    //ROBIENIE TURY
    public override bool TakeTurn(Map map, List<Character> characters)
    {
        bool isPlaying = true; //<tak, gram
        var input = Console.ReadKey(true); //< tak, coś kliknąłem
        Console.SetCursorPosition(_position.X, _position.Y);
        Cell previousCell = map.GetCell(_position.X, _position.Y); //< a tu sięznajduję

        if (_inputMap.ContainsKey(input.Key))
        {
            Vector2 direction = _inputMap[input.Key];
            bool moved = Move(direction, map);

            if (moved) //F2 to RENAME!!!!
            {
                previousCell.Leave();
                previousCell.Display();
                // jeżeli ruch się udał, to opróżij komórkę na której byłeś
                
                Cell currentCell = map.GetCell(_position.X, _position.Y);
                //NEXT LVL STAIRCASE
                if (currentCell.Visuals == '>')
                {
                    
                    //można też zrobić prościej i ich po prostu teleportowąc, nie kasować, idke
                    _lvlManager.LoadLvl($"level{currentLVLnumber+1}");
                     
                     map.Display();
                     currentLVLnumber++;
                }
                //END GAME
                if (currentCell.Visuals == '»')
                {
                    Console.Clear();
                    //Program.Main().; jak zniszczyć npcta? i bohatera
                    
                    isPlaying = false;
                   //lvlManager.NPCs.Clear();
                   //characters.Clear();
                    int x = 30;
                    int y = 5;
                    Console.SetCursorPosition(x,y);
                    if (Program.playTime > 180)
                    {
                        Console.Write("TOO SLOW! YOU LOST!");
                    }
                    else
                    {
                        Console.Write("YOU WON!!!");
                        
                    }
                    Console.SetCursorPosition(x -4,y + 1);
                    Console.WriteLine($"Your time: {Program.playTime}");
                    Console.SetCursorPosition(x -11,y + 2);
                    Console.WriteLine("[press ENTER to close the game]");
                    Console.ReadLine();
                    Environment.Exit(0);

                }
                //RIDDLE
                if (currentCell.Visuals == '?')
                {
                    
                    
                    isPlaying = false;
                    //lvlManager.NPCs.Clear();
                    //characters.Clear();
                    
                    int x = 30;
                    int y = 0;
                    Console.SetCursorPosition(x,y);
                    Console.Write("It is greater than God and more evil than the devil. The poor have it, the rich need it and if you eat it you’ll die. What is it?");
                    string correctAnswer = "nothing";
                    string answer;
                    do
                    {
                        Console.SetCursorPosition(x,y + 1);
                     answer = Console.ReadLine();
                     if (answer != correctAnswer)
                     {
                        Console.SetCursorPosition(x,y + 1);
                        Console.WriteLine("                        ");
                        
                        Console.SetCursorPosition(x,y + 2);
                        Console.Write("WRONG ANSWER! Try again!");
                         
                     }
                     else
                     {
                         Console.SetCursorPosition(x,y);
                         Console.WriteLine("                                                                                                                                             ");
                         Console.SetCursorPosition(x,y + 1);
                         Console.WriteLine("                        ");
                         Console.SetCursorPosition(x,y + 2);
                         Console.WriteLine("                        ");
                         break;
                     }
                        
                    } while (answer != correctAnswer);
                    
                    

                }
                
                //LAVA
                if (currentCell.Visuals == '~')
                {
                    life -= 1;
                }
                
                //DEATH from dmg
                if (life <= 0)
                {
                    Console.Clear();
                    //Program.Main().; jak zniszczyć npcta? i bohatera
                    
                    isPlaying = false;
                    //lvlManager.NPCs.Clear();
                    //characters.Clear();
                    int x = 30;
                    int y = 5;
                    Console.SetCursorPosition(x,y);
                    
                    
                        Console.Write("You've burned in lava! YOU ARE DEAD!");
                    
                    
                    
                    Console.SetCursorPosition(x -11,y + 2);
                    Console.WriteLine("[press ENTER to close the game]");
                    Console.ReadLine();
                    Environment.Exit(0);

                }
            }
        }
        else
        {//INNE FUNKCJE oprócz poruszania
            switch (input.Key)
            {
                case ConsoleKey.Q: //PAUZA
                    isPlaying = false;
                    break;
                case ConsoleKey.I: //POKAŻ EKWIPUNEK
                    _inventory.Display();
                    Console.ReadKey(true);
                    _inventory.Hide();
                    break;
            }
        }

        Display(); // < tura z zasady kończy się tym, że displayiujemy rzeczy na nowo xd zawsze
        return isPlaying;

    }
}