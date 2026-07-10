namespace GrTypuRouglike;

public abstract class Character : GameObject
{
    protected Inventory _inventory; //<< stworzyć inventory

    public Character(char avatar, Vector2 startingPosition, Map map) : base(avatar, startingPosition)
    {
        _inventory = new Inventory(); //<< każdy charakter ma swoje
        Cell cell = map.GetCell(_position.X, _position.Y);
        cell.Occupant = this; // zajmuje komórkę
    }

    public bool Move(Vector2 direction, Map map)
    {
        return Move(direction.X, direction.Y, map);
    }//to jest skrótowiec do tego co na dole

    public bool Move(int diffX, int diffY, Map map)
    {
        // nasza pozycja + kierunek = nasz ruch
        int targetX = _position.X + diffX;
        int targetY = _position.Y + diffY;

        if (targetY >= 0 && targetY < Console.BufferHeight && targetY < map.GetHeight())
        {// dużo zabezpieczeń, ponad zero, mniejsze niż konsola i niż wysokość mapy
            if (targetX >= 0 && targetY < Console.BufferWidth && targetX < map.GetRowWidth(targetY))
            {
                Cell cell = map.GetCell(targetX, targetY);
                if (cell.Visuals == '▓' || cell.IsOccupied() || (cell.Visuals == '|' && !_inventory.Has('*') || (cell.Visuals == '-' && !_inventory.Has('*')))) //Symbol '|' i '-' to drzwi
                {
                    return false;
                }
                
                if (cell.Visuals == '|' || cell.Visuals == '-' && _inventory.Has('*'))
                {
                    RemoveItemByAvatar('*');
                }
                
                // czy nie ma na drodze ruchu ściany lub okupanta (NPC? ITEM?)
                    // i dopiero teraz możemy XD
                _position.Y = targetY;
                _position.X = targetX;
                    
                cell.Occupy(this);
                if (cell.HasItem())
                {
                    AddItem(cell.TakeItem()); // po to ta funkcja xdd, jeżeli wejdzie na item to bierze ko z komórki i daje do inventory
                }
                return true; //<< ruch się udał
            }
            
        }

        return false; // <wymagania nie spełnione, ruch się nie udał
        
    }
    
    private void RemoveItemByAvatar(char c)
    {
        _inventory.RemoveItemByAvatar(c);
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public abstract bool TakeTurn(Map map, List<Character> characters); //<< hmmm????????????
    
}