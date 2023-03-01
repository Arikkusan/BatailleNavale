namespace BatailleNavale;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public List<Boat> boats;            // liste de bateau sur la Map (en vie ou non)
    public Map map;
    private bool hasTouched = false;
    private direction direct = direction.Rien;


    public Player()
    {
        this.nbBoat = 10;
        this.boats = new List<Boat>();
        this.map = new Map();
    }

    public void AttackAuto(Player enemy)
    {
        // random x y 
        int x = new Random().Next(0, 10);
        int y = new Random().Next(0, 10);
        int x2 = x;
        int y2 = y;

        if (hasTouched == true)
        {
            if (direct == direction.Rien) 
            {
                int ranDirect = new Random().Next(1, 5);
                if (ranDirect == 1) { x2++; }
                else if (ranDirect == 2) { x2--; }
                else if (ranDirect == 3) { y2++; }
                else { y2--; }


            }


            

        }
        else
        {
            AttackCase(x, y, enemy);
        }
    }

    private void AttackCase(int x, int y, Player enemy)
    {
        if (!enemy.map.GetCase(x, y).isTouched)
        {
            enemy.map.GetCase(x, y).isTouched = true;

            if (enemy.map.GetCase(x, y).isUsed)
            {
                enemy.map.GetCase(x, y).Boat.Touch();
                if (enemy.map.GetCase(x, y).Boat.IsAlive())
                {
                    hasTouched = true;
                }
                else
                {
                    hasTouched = false;
                }
            }
        }
    }
    public enum direction
    {
        Haut,
        Bas,
        Droite,
        Gauche,
        Rien
    }
}
