namespace GrTypuRouglike;

public class Cell
{
    public Character Occupant; // << stworzyć charakter
    public char Visuals;
    public Item? Item { get; set; } // << stworzyć Item

    public void Display()
    {
        if (IsOccupied())
        {
            Occupant.Display();
            // ** więc, Display() będzie funkcją w klasie Character?? albo w Game object? SIę zobaczy. Wolałbym w GameObject.
        }
        else if (HasItem())
        {
            Item.Display();
            // ** no zdecydowanie bym wolał w GameObject XDDD
        }
        else
        {
            Console.Write(Visuals);
            //bardzo fajne, jeżeli nie ma itemu ani charactera to po prostu wyświetlamy tło mapy, mądre
        }
    }

    public bool IsOccupied()
    {
        return Occupant != null;
    }

    public bool HasItem()
    {
        return Item != null;
        // poptrz, item jest i istniej (w tej komórce)
    }

    // VV ta funcka będzie chyba do spawnowania itemków
    public void PutItem(Item item)
    {
        Item = item;
    }
    
    // VV a ta do opróżniania komórki po ich podniesieniu
    public void TakeItem()
    {
        Item item = Item;
        Item = null;
        
        return item;
        // hehe, czyli czyni pustym tą komórkę item a zmienna item staje się tym itemem co był w tej komórce?
        //item item item pfffff wiele mi to mówi
    }
    
    /// <summary>
    /// Place character on this cell by putting it into Occupant field.
    /// </summary>
    /// <param name="character">Character to put into Occupant field</param>
    /// ^^ nie wiem co to, ale kopiuje na wszelki wypadek
    public void Occupy(Character character)
    {
        Occupant = character;
    }

    public void Leave()
    {
        Occupant = null;
        //dowidzenia
    }
    
    
    //▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
    /* PODSUMOWAWSZY:
     > dużo różnych funkcji
     ..........
     >komórka może być occupied lub nie
     > jeżeli JEST to może mieć w sobie character lub Item (i go Displayiuje)
     > a jeżeli NIE JEST to wyświetla tło (Visuals)
     ..........
     > szczerze, nie bardzo rozumiem jeszcze tą kwestie putitem i inne, i czemu one w ogóle są
     we właściwościach akurat komórki??/ mało praktyczne się wydaje
     */
}