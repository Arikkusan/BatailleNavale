namespace BatailleNavale;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public List<Boat> boats;            // liste de bateau sur la Map (en vie ou non)
    public Map map;
    private e toucheCoule = e.RIEN;
    private bool isAlive = false;
    private direction direct = direction.Rien;
    private int x, y;


    public Player()
    {
        this.nbBoat = 10;
        this.boats = new List<Boat>();
        this.map = new Map();
    }

    public void AttackAuto(Player enemy)
    {
        if (isAlive)
        {
            toucheCoule = e.TOUCHE;
        }
        else
        {
            direct = direction.Rien;
        }

        switch (toucheCoule)
        {
            case e.RIEN:
            case e.COULE:
                AttackRIENCOULE(enemy);
                break;

            case e.TOUCHE:
                AttackTOUCHE(enemy);
                break;
        }
    }

    private void AttackRIENCOULE(Player enemy)
    {
        x = new Random().Next(0, 10);
        y = new Random().Next(0, 10);
        
        if (enemy.map.touchable(x, y))
        {
            toucheCoule = enemy.map.attack(x, y);
        }
        else
        {
            AttackRIENCOULE(enemy);
        }
    }

    private void AttackTOUCHE(Player enemy)
    {
        int x2 = x;
        int y2 = y;
        if (direct == direction.Rien)
        {
            int ranDirect = new Random().Next(1, 5);
            if (ranDirect == 1) { x2++; }
            else if (ranDirect == 2) { x2--; }
            else if (ranDirect == 3) { y2++; }
            else { y2--; }
            


        }
    }
    private void AttackCase(int x,int y, Player enemy)
    {
        toucheCoule = enemy.map.Attack(x, y);
        isAlive = enemy.map.boatAlive(x, y);
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
