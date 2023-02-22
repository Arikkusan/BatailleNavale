namespace BatailleNavale;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public Boat[] boats;            // liste de bateau sur la Map (en vie ou non)
    public Map map;


    public Player()
    {
        this.nbBoat = 10;
        this.boats = new Boat[10];
    }
}

public class Bot : Player
{
    public Bot()
    {
        this.nbBoat = 5;
    }

    public void InitBoats()
    {

        foreach (var boat in boats)
        {
            //boat = new Boat(1, new Coordinates(0, 0),new Coordinates(1, 0));
        }
    }
}