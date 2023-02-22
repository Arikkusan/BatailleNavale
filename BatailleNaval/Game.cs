namespace BatailleNaval;

public class Game
{
    private Map botMap;
    private Map userMap;
    private int roundCount;
    

    public Game()
    {
        
    }

    public void Start()
    {
        DrawGameMap();
    }

    private void DrawGameMap()
    {
        Map m = new Map();
        m.initMap();
        
        Map.ShowMaps(m, m);
    }
}