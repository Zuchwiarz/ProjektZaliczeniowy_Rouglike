namespace GrTypuRouglike;

public class VecticalNPC: Character
{
    private readonly List<Vector2> availableDirections = [
        //new Vector2(-1, 0), // w lewo
        //new Vector2(1, 0), // w prawo
        new Vector2(0, -1), // w górę
        new Vector2(0, 1) // w dół
    ];
    private Vector2 direction;

    private void ChooseRandomDirection()
    {
        int index = Random.Shared.Next(availableDirections.Count);
        direction = availableDirections[index];
    }

    public VecticalNPC(char avatar, Vector2 startingPosition, Map map) : base(avatar, startingPosition, map)
    {
        ChooseRandomDirection();
    }

    public override bool TakeTurn(Map map, List<Character> characters)  
    {
        //to jest po prostu to, jak wygląda TAKE TURN, tura w wykonaniu NPCta
        Console.SetCursorPosition(_position.X, _position.Y);
        Cell cell = map.GetCell(_position.X, _position.Y);
        
        //  ta sekcja to poruszanie się npcta, jego zasady
        //opuszczanie komórek, wyświetlanie itd.
       
        if (Move(direction, map))
        {
            cell.Leave();
            cell.Display();
        }
        else
        {
            ChooseRandomDirection();
        }
        Display();
        return true;
        
        
    }
}