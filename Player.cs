using System.Numerics;

namespace GrTypuRouglike;

public class Player : Character
{
    private readonly Dictionary<ConsoleKey, Vector2> _inputMap;

    public Player(char avatar, Vector2 startingPosition, Map map, Dictionary<ConsoleKey, Vector2> inputMap) : base(avatar, startingPosition, map)
    {
        _inputMap = inputMap;
        // aha? po prostu przypisujemy graczowi sterowanie?
    }

    //ROBIENIE TURY
    public override bool TakeTurn(Map map)
    {
        bool isPlaying = true; //<tak, gram
        var input = Console.ReadKey(true); //< tak, coś kliknąłem
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
                if (currentCell.Visuals == '>')
                {
                     map.LoadFromFile("leve2");
                     map.Display();
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