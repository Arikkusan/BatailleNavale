namespace BatailleNavale;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public List<Boat> boats;            // liste de bateau sur la Map (en vie ou non)
    public Map map;


    public Player()
    {
        this.nbBoat = 10;
        this.boats = new List<Boat>();
        this.map = new Map();
    }
}

