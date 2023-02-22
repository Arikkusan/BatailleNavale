namespace BatailleNaval;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public Boat[] boats;            // liste de bateau sur la Map (en vie ou non)


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

    public void initBoats()
    {
        int boat4 = 2;
        int boat3 = 3;
        int boat2 = 4;
        int boat1 = 5;

        foreach (var boat in boats)
        {
            //boat = new Boat(1, new Coordinates(0, 0),new Coordinates(1, 0));
        }
    }
}