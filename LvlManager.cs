namespace GrTypuRouglike;

public class LvlManager
{
    public Map currentMap;
    public List<Character> NPCs;
        public LvlManager(Map map)
        {
           // currentMap = map;
           Map currentMap = map;
        }
    

    public void LoadLvl(string lvlNAME) //w playerze będzie rosnąć o 1
    {
        
        
        currentMap.LoadFromFile(lvlNAME);
        
        //Items spawn on LVL
        Item iten = new Item('*', new Vector2(1, 2), currentMap);
        

        

        //NPC's spawn on LVL
        Vector2 startingPosition = new Vector2(4, 2);
        
        startingPosition.X = 1;
        startingPosition.Y = 1;

        //lista npctów dla każdego lvla
        // VV tworzymy NPC
        Character npc1 = new Npc('$', startingPosition, currentMap);
        //dodaje nnpc do listy npctów
        NPCs.Add(npc1);

        currentMap.Display();
    }
}