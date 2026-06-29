namespace GrTypuRouglike;

public class Item: GameObject
{
    public Item(char avatar, Vector2 position, Map map) : base(avatar, position)
    {
        //konstruktor itema
        //w nim mogę w sumie dać jego właściwości
        Cell cell = map.GetCell(_position.X, _position.Y);
        cell.PutItem(this);
        
        // ^^^a więc item w samej swojej strukturze zawiera miejsce w któym będzie postawiony
        //jakież to filozoficzne głębokie
        // i deterministyczne

    }
}