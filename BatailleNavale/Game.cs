namespace BatailleNavale;

public class Game
{
    public static Game Instance;
    private Player Bot;
    private Player User;

    private Map _botMap;
    private Map _userMap;
    private int _roundCount;
    private static bool _multiplayer;


    public Game()
    {
        Instance = this;

        _roundCount = 0;

        this.Bot = new Player();
        this.User = new Player();

        _botMap = Bot.map;
        _userMap = User.map;

        _botMap.PlaceBoats(Bot, false);
        _userMap.PlaceBoats(User, false);


        Start();
    }

    private void Start()
    {
        bool gameFinished = false;
        string caseAttacked;
        for (int i = 0; i < 20; i++)
        {
            DrawGameMap();
            Bot.AttackAuto(User);
        }

        DrawGameMap();
        while (!gameFinished)
        {
            bool attackReached = false;
            while (!attackReached)
            {
                Console.WriteLine("Quelle case souhaitez-vous attaquer ?");
                caseAttacked = Console.ReadLine();
                if (caseAttacked == null)
                    caseAttacked = "";

                if (Coordinates.IsCoordinate(caseAttacked))
                {
                    User.AttackPlayer(Coordinates.ConvertTextInput(caseAttacked));
                }
                else
                {
                    Console.WriteLine("Veuillez recommencer.");
                }
            }

            Bot.AttackAuto(User);

            if (User.nbBoat == 0 || Bot.nbBoat == 0)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        IHM.Clear();
        if (User.nbBoat == 0)
        {
            Console.WriteLine("Bravo ! Vous avez remporté la partie.");
        }
        else
        {
            Console.WriteLine("Vous avez perdu la partie.");
        }
    }

    private void DrawGameMap()
    {
        Map.ShowMaps(_botMap, _userMap);
    }

    public static void Init()
    {
        Console.WriteLine("┌──────────────────────────────────┐");
        Console.WriteLine("│        LA BATAILLE NAVALE        │");
        Console.WriteLine("└──────────────────────────────────┘");
        Console.WriteLine();
        Console.WriteLine("Jouez-vous tout seul ou avec un amis ?");

        // Input

        Console.WriteLine("Joueur 1, quel-est votre nom ?");
        // input

        if (_multiplayer)
        {
            Console.WriteLine("Joueur 2, quel-est votre nom ?");
            // input
        }

        // placer ses bateaux ? oui non pour chaque joueurs s'il y en a 2

        Console.WriteLine("Que la partie commence !");
        Console.Clear();


        // Demander à l'utilisateur si c'est contre un bot / un joueur
        // s'il veut un nb de tour max, changer le nb de bateaux

        _multiplayer = false;
    }

    public Player getBot()
    {
        return Bot;
    }

    public Player getUser()
    {
        return User;
    }

    public static Game GetInstance()
    {
        return Instance;
    }
}