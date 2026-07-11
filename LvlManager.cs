namespace GrTypuRouglike;

public class LvlManager
{
    public Map currentMap;
    public List<Character> NPCs = new List<Character>();

    public LvlManager(Map map)
    {
        // currentMap = map;
        currentMap = map;
        ;
    }


        private void TeleportNpc(Character npc, Vector2 newPosition)
        {
            Cell previousCell = currentMap.GetCell(npc._position.X, npc._position.Y);
            previousCell.Leave();
            previousCell.Display();
            npc._position = newPosition;
            Cell currentCell = currentMap.GetCell(npc._position.X, npc._position.Y);
            currentCell.Occupy(npc);
            npc.Display();
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
            case "level2":
                // Item itemm = new Item('*', new Vector2(4, 5), currentMap);
                
                break;
            case "level3":
                Item item = new Item('*', new Vector2(2, 16), currentMap);
                
                break;
        }
        

        

        //NPC's spawn/teleports on LVL
        
        
        //lista npctów dla każdego lvla
        
        // VV tworzymy  wszystkich NPC
        if (lvlNAME == "level1")
        {
            Vector2 startingPosition = new Vector2(1, 1);
            Character npc1 = new HorizontalNpc('$', startingPosition, currentMap);
            NPCs.Add(npc1);
            Vector2 startingPosition2 = new Vector2(2, 1);
            Character npc2 = new HorizontalNpc('$', startingPosition2, currentMap);
            NPCs.Add(npc2);
            Vector2 verticalStart = new Vector2(8, 5);
            Character npc3 = new VecticalNPC('&', verticalStart, currentMap);
            NPCs.Add(npc3);
            Vector2 verticalStart2 = new Vector2(9, 5);
            Character npc4 = new VecticalNPC('&', verticalStart2, currentMap);
            NPCs.Add(npc4);
            
        }
        else
        {
            switch (lvlNAME)
            {
                case "level2":
                    Character npc = NPCs[0];
                TeleportNpc(NPCs[0], new Vector2(15, 12));
                // do uzupełnienia.
                
                    break;
            }
        }
        
       
        //dodaje nnpc do listy npctów


        currentMap.Display();
        
        
        //switch na lvlname setuje starting possition, czy tam current position
    }
}