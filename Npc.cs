namespace GrTypuRouglike;

public class Npc: Character
{
    List<Vector2> availableDirections = [
        new Vector2(-1, 0), // w lewo
        new Vector2(1, 0), // w prawo
        //new Vector2(0, -1), // w górę
       // new Vector2(0, 1) // w dół
    ];

    public Npc(char avatar, Vector2 startingPosition, Map map) : base(avatar, startingPosition, map)
    {
        //konstruktor
    }

    public override bool TakeTurn(Map map, List<Character> characters) //<< muszę ogarnąć co to OVERRIDE ;_;
    {
        //to jest po prostu to, jak wygląda TAKE TURN, tura w wykonaniu NPCta
        Console.SetCursorPosition(_position.X, _position.Y);
        Cell cell = map.GetCell(_position.X, _position.Y);
        
        //  ta sekcja to poruszanie się npcta, jego zasady
        //opuszczanie komórek, wyświetlanie itd.
        int index = Random.Shared.Next(availableDirections.Count); // << KIERUNEK LOSOWY
        Vector2 direction = availableDirections[index];
        if (Move(direction, map))
        {
            cell.Leave();
            cell.Display();
        }
        Display();
        return true;
        
        
    }
}