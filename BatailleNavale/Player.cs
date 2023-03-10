namespace BatailleNavale;

public class Player
{
    public int nbBoat { get; set; } // compteur de cases utilisées restantes
    public List<Boat> boats; // liste de bateau sur la Map (en vie ou non)
    public Map map;
    private e toucheCoule = e.RIEN;
    private direction direct = direction.Rien;
    private List<direction> listDirect = new List<direction>();
    private int x, y;
    private int z = 0;


    public Player()
    {
        this.nbBoat = 10;
        this.boats = new List<Boat>();
        this.map = new Map();
    }

    public void AttackAuto(Player enemy)
    {
        /*if (x != null)
        {
            if (enemy.map.verifIsAlive(x, y))
            {
                toucheCoule = e.TOUCHE;
            }
            else
            {
                direct = direction.Rien;
            }
        } */ // Pas sûr d'en avoir besoin    

        switch (toucheCoule)
        {
            case e.RIEN:
            case e.COULE:
                AttackRIENCOULE(enemy);
                break;

            case e.RATE:
                AttackRATE(enemy);
                break;

            case e.TOUCHE:
                AttackTOUCHE(enemy);
                break;
        }
    }

    private void AttackRATE(Player enemy)
    {
        listDirect.Add(direct);
        direct = chooseDirect();
        AttackTOUCHE(enemy);
    }

    private void AttackRIENCOULE(Player enemy)
    {
        reset();
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
        bool hasTouched = false;
        while (!hasTouched)
        {
            switch (direct)
            {
                case direction.Rien:
                    direct = chooseDirect();
                    break;

                case direction.Haut:
                    x2 = x + 1 + z;
                    if (x2 < 10)
                    {
                        if (enemy.map.touchable(x2, y))
                        {
                            toucheCoule = enemy.map.attack(x2, y);
                            hasTouched = true;

                            if (toucheCoule == e.RIEN)
                            {
                                toucheCoule = e.RATE;
                            }
                            else
                            {
                                z += 1;
                            }
                        }
                    }

                    break;

                case direction.Bas:
                    x2 = x - 1 - z;
                    if (x2 >= 0)
                    {
                        if (enemy.map.touchable(x2, y))
                        {
                            toucheCoule = enemy.map.attack(x2, y);
                            hasTouched = true;

                            if (toucheCoule == e.RIEN)
                            {
                                toucheCoule = e.RATE;
                            }
                            else
                            {
                                z += 1;
                            }
                        }
                    }

                    break;

                case direction.Droite:
                    y2 = y + 1 + z;
                    if (y2 < 10)
                    {
                        if (enemy.map.touchable(x, y2))
                        {
                            toucheCoule = enemy.map.attack(x, y2);
                            hasTouched = true;

                            if (toucheCoule == e.RIEN)
                            {
                                toucheCoule = e.RATE;
                            }
                            else
                            {
                                z += 1;
                            }
                        }
                    }

                    break;

                case direction.Gauche:
                    y2 = y - 1 - z;
                    if (y2 > 0)
                    {
                        if (enemy.map.touchable(x, y2))
                        {
                            toucheCoule = enemy.map.attack(x, y2);
                            hasTouched = true;

                            if (toucheCoule == e.RIEN)
                            {
                                toucheCoule = e.RATE;
                            }
                            else
                            {
                                z += 1;
                            }
                        }
                    }

                    break;
            }
        }
    }

    private direction chooseDirect()
    {
        int x = new Random().Next(1, 5);
        direction d = direction.Rien;

        switch (x)
        {
            case 1:
                if (!verifListDirect(direction.Haut))
                {
                    d = direction.Haut;
                }

                break;
            case 2:
                if (!verifListDirect(direction.Bas))
                {
                    d = direction.Bas;
                }

                break;
            case 3:
                if (!verifListDirect(direction.Droite))
                {
                    d = direction.Droite;
                }

                break;
            case 4:
                if (!verifListDirect(direction.Gauche))
                {
                    d = direction.Gauche;
                }

                break;
        }

        return d;
    }

    private bool verifListDirect(direction d)
    {
        for (int i = 0; i < listDirect.Count; i++)
        {
            if (listDirect[i] == d)
            {
                return true;
            }
        }

        return false;
    }

    private void reset()
    {
        x = 0;
        y = 0;
        z = 0;
        listDirect.Clear();
        direct = direction.Rien;
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