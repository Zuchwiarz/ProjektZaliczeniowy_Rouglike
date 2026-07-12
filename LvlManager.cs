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

        Console.Clear();
        currentMap.LoadFromFile(lvlNAME);
       
        
        //Items spawn on LVL
        switch (lvlNAME)
        {
            case "level1":
                Random r = new Random();
                int rInt = r.Next(47, 51);
                Item itm = new Item('*', new Vector2(9, 19), currentMap);
                Item ite = new Item('*', new Vector2(rInt, 17), currentMap);
                Item iten = new Item('*', new Vector2(32, 9), currentMap);
                break;
            case "level2":
                Item itemm = new Item('*', new Vector2(60, 13), currentMap);
                Item it = new Item('*', new Vector2(46, 21), currentMap);
                Item itn = new Item('*', new Vector2(11, 6), currentMap);
                Item itp = new Item('*', new Vector2(72, 17), currentMap);
                Item itq = new Item('*', new Vector2(120, 10), currentMap);
                Item itk = new Item('*', new Vector2(85, 4), currentMap);
                break;
        }
        

        

        //NPC's spawn/teleports on LVL
        
        
        //lista npctów dla każdego lvla
        
        // VV tworzymy  wszystkich NPC
        if (lvlNAME == "level1")
        {
            Random r = new Random();
            int rInt = r.Next(9, 13);
            Vector2 startingPosition = new Vector2(9, 22);
            Character npc1 = new HorizontalNpc('$', startingPosition, currentMap);
            NPCs.Add(npc1);
            Vector2 startingPosition2 = new Vector2(35, 8);
            Character npc2 = new HorizontalNpc('$', startingPosition2, currentMap);
            NPCs.Add(npc2);
            Vector2 startingPosition3 = new Vector2(12, 20);
            Character npc3 = new HorizontalNpc('$', startingPosition3, currentMap);
            NPCs.Add(npc3);
            Vector2 verticalStart = new Vector2(9, rInt);
            Character npc4 = new VecticalNPC('&', verticalStart, currentMap);
            NPCs.Add(npc4);
            Vector2 verticalStart2 = new Vector2(13, 9);
            Character npc5 = new VecticalNPC('&', verticalStart2, currentMap);
            NPCs.Add(npc5);
            Vector2 verticalStart3 = new Vector2(45, 13);
            Character npc6 = new VecticalNPC('&', verticalStart3, currentMap);
            NPCs.Add(npc6);
            
        }
        else
        {
            switch (lvlNAME)
            {
                case "level2":
                    TeleportNpc(NPCs[0], new Vector2(11, 9));
                    TeleportNpc(NPCs[1], new Vector2(11, 15));
                    TeleportNpc(NPCs[2], new Vector2(111, 11));
                    TeleportNpc(NPCs[3], new Vector2(85, 20));
                    TeleportNpc(NPCs[4], new Vector2(60, 16));
                    TeleportNpc(NPCs[5], new Vector2(45, 16));
                break;
                
                
                    
            }
        }
        
       
        //dodaje nnpc do listy npctów


        currentMap.Display();
        
        
        //switch na lvlname setuje starting possition, czy tam current position
    }
}