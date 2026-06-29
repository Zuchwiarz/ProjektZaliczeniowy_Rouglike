namespace GrTypuRouglike;

public class Inventory
{
    private List<Item> _items = [];

    //DODAWANIE ITEMU
    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Display()
    {
        //pozycja wyświtlania inventory
        int x = 30;
        int y = 0;
        Console.SetCursorPosition(x,y);
        Console.WriteLine("Inventory");
        y++;
        //WYŚWIETLANIE ITEMÓW W INVENTORY
        foreach (Item item in _items)
        {
            item.Display(new Vector2(x,y));
            y++;
        }
    }

    public void Hide()
    {
        int x = 30;
        for (int y = 0; y < _items.Count + 1; y++)
        {
            Console.SetCursorPosition(x,y);
            Console.WriteLine("                        ");
            //^ kasujemy widok
        }
    }
    
    
}