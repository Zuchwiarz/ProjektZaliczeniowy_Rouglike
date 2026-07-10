using System.Numerics;

namespace GrTypuRouglike;

public class Player : Character
{
    public bool gameEND;
    int currentLVLnumber = 1;
    
    private readonly Dictionary<ConsoleKey, Vector2> _inputMap;

    public Player(char avatar, Vector2 startingPosition, Map map, Dictionary<ConsoleKey, Vector2> inputMap) : base(avatar, startingPosition, map)
    {
        _inputMap = inputMap;
        // aha? po prostu przypisujemy graczowi sterowanie?
    }

    

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
                    LvlManager lvlManager = new LvlManager(map);
                if (currentCell.Visuals == '>')
                {
                    //TODO: mapa musi się kasować i tworzyć nowa
                    //TODO: npcty nowe się nie poruszają, trzeba czyścić listę i tworzyć nową
                    //TODO: oprócz tego dodać różne poziomy do lvl managera i ilość npctów
                    //można też zrobić prościej i ich po prostu teleportowąc, nie kasować, idke
                    lvlManager.LoadLvl($"level{currentLVLnumber+1}");
                     
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
                    Console.Write("YOU WON!");
                    Console.SetCursorPosition(x -5,y + 1);
                    Console.WriteLine("Your time: ");

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