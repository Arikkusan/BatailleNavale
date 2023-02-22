using BatailleNavale;

namespace BatailleNavale;

public class Game
{
    public const int BoatCount = 15;
    public static Player Bot;
    public static Player Player;

    private Map _botMap = Bot.map;
    private Map _userMap = Player.map;
    private int _roundCount;
    private static bool _multiplayer;


    public Game()
    {
        _roundCount = 0;
     
        
        
        _botMap = new Map();
        _botMap.InitMap();
        _botMap.PlaceBoats(_multiplayer);

        _userMap = new Map();
        _userMap.InitMap();
        
        _userMap.PlaceBoats(true);
        

    }

    public void Start()
    {
        DrawGameMap();
    }

    private void DrawGameMap()
    {
        
        Map.ShowMaps(_botMap, _userMap);
    }

    public static void Init()
    {
        // Demander à l'utilisateur si c'est contre un bot / un joueur
        // s'il veut un nb de tour max, changer le nb de bateaux

        _multiplayer = false;
    }
}