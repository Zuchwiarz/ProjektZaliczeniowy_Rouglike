namespace GrTypuRouglike;

public class LvlManager
{
    public Map currentMap;
    public List<Character> NPCs = new List<Character>();
        public LvlManager(Map map)
        {
           // currentMap = map;
           currentMap = map;
        }
    

    public void LoadLvl(string lvlNAME) //w playerze będzie rosnąć o 1
    {
        
        
        currentMap.LoadFromFile(lvlNAME);
        
        //Items spawn on LVL
        //tutaj decydujemy gdzie itemy spawnią sięna każdym lvlu
        //stare itemy nie są usuwane, więc każdy musi być "obowiązkowy" do zebrania
        switch (lvlNAME)
        {
            case "level1":
            Item itm = new Item('*', new Vector2(15, 12), currentMap);
                break;
            case "level2":
           // Item itemm = new Item('*', new Vector2(4, 5), currentMap);
                
                break;
            case "level3":
            Item item = new Item('*', new Vector2(2, 16), currentMap);
                
                break;
        }
        
        

        
        //czyszczenie starych NPC
        foreach (Character npc in NPCs)
        {
            Map map = new Map();
            Cell cell = currentMap.GetCell(npc._position.X, npc._position.Y);
            cell.Visuals =' ';
            cell.Leave();
        }
        //NPC's spawn/teleports on LVL
        Vector2 NPC1startingPosition = new Vector2(1, 1);
        
        //lista npctów dla każdego lvla
        // VV tworzymy NPC
        Character npc1 = new Npc('$', NPC1startingPosition, currentMap);
        //dodaje nnpc do listy npctów
        NPCs.Add(npc1);

        currentMap.Display();
    }
}