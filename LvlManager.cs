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
        switch (lvlNAME)
        {
            case "level1":
                Item itm = new Item('*', new Vector2(15, 12), currentMap);
                break;
            //case "level2":
                //Item itemmm = new Item('*', new Vector2(31, 5), currentMap);
                //Item itemm = new Item('*', new Vector2(47, 13), currentMap);
                
                //break;
            case "level3":
                Item item = new Item('*', new Vector2(2, 16), currentMap);
                
                break;
        }
        

        

        //NPC's spawn/teleports on LVL
        
        
        //lista npctów dla każdego lvla
        
        // VV tworzymy  wszystkich NPC
        Vector2 startingPosition = new Vector2(1, 1);
        Character npc1 = new HorizontalNpc('$', startingPosition, currentMap);
        NPCs.Add(npc1);
        Vector2 verticalStart = new Vector2(8, 5);
        Character npc2 = new VecticalNPC('&', verticalStart, currentMap);
        NPCs.Add(npc2);
        
        switch (lvlNAME)
        {
            case "level2":
                
                // wyczyścić komórkę .GetCell
                
                npc1._position = new Vector2(5, 5);
                //npc2._position = new Vector2(35, 9);
                
                
                break;
        }
        //dodaje nnpc do listy npctów


        currentMap.Display();
    }
}