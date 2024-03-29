﻿namespace BatailleNavale;

public class Map
{
    public Case[,] _boatMap { get; }

    private readonly int _boat4 = 2;
    private readonly int _boat3 = 3;
    private readonly int _boat2 = 4;
    private readonly int _boat1 = 5;

    public Map()
    {
        _boatMap = new Case[10, 10];
        InitMap();
    }

    public Case GetCase(int x, int y)
    {
        if (x < 0 || x > 9 || y < 0 || y > 9)
            throw new Exception("Valeur attendu fausse : Voir GetCase(int x, int y) dans Map.cs");

        return _boatMap[x, y];
    }

    private void InitMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _boatMap[i, j] = new Case();
            }
        }
    }


    public static void ShowMaps(Map leftMap, Map rightMap)
    {
        Console.WriteLine(
            "        ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐      │          ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
        Console.WriteLine(
            "        │ A │ B │ C │ D │ E │ F │ G │ H │ I │ J │      │          │ A │ B │ C │ D │ E │ F │ G │ H │ I │ J │");
        Console.WriteLine(
            "    ┌───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤      │      ┌───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");


        for (int i = 0; i < 10; i++)
        {
            Console.Write("    ");

            for (int j = 0; j < 10; j++)
            {
                leftMap.WriteCell(i, j);
            }

            Console.Write("│");
            Console.Write("      │      ");

            for (int j = 0; j < 10; j++)
            {
                rightMap.WriteCell(i, j);
            }

            Console.Write("│");
            Console.WriteLine();

            if (i == 9)
            {
                Console.WriteLine(
                    "    └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘      │      └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            }
            else
            {
                Console.WriteLine(
                    "    ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤      │      ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            }
        }
    }

    private void WriteCell(int i, int j)
    {
        if (j == 0)
        {
            Console.Write("│ " + i + " ");
        }


        if (_boatMap[i, j].isUsed)
        {
            if (_boatMap[i, j].isTouched)
            {
                Console.Write("│ O ");
            }
            else
            {
                Console.Write("│ B ");
            }
        }
        else
        {
            if (_boatMap[i, j].isTouched)
            {
                Console.Write("│ X ");
            }
            else
            {
                Console.Write("│   ");
            }
        }
    }

    public void PlaceBoats(Player p, bool isPlayer)
    {
        if (isPlayer)
            PlaceBoatsByPlayer();
        else
            PlaceBoatsAuto(p);


    }

    private void PlaceBoatsAuto(Player p)
    {
        PlaceBoatsBySize(p, _boat1, 1);
        PlaceBoatsBySize(p, _boat2, 2);
        PlaceBoatsBySize(p, _boat3, 3);
        PlaceBoatsBySize(p, _boat4, 4);
    }

    private void PlaceBoatsBySize(Player p, int nbBoat, int boatSize)
    {
        for (int i = 0; i < nbBoat; i++)
        {
            PlaceBoatBySize(p, boatSize);
        }
    }

    private void PlaceBoatBySize(Player p, int boatSize)
    {
        Map m = p.map;

        // random x y 
        int x = new Random().Next(0, 10);
        int y = new Random().Next(0, 10);

        // si case non prise alors random haut bas gauche droite jusqu'à + size
        Case c = m.GetCase(x, y);

        while (c.isUsed)
        {
            x = new Random().Next(0, 10);
            y = new Random().Next(0, 10);
            c = m.GetCase(x, y);
        }

        // Random pour orientation
        int orientation = new Random().Next(0, 2);
        bool possibleBack = true;
        bool possibleFront = true;
        List<Case> cases = new List<Case>();

        switch (orientation)
        {
            case 0: // horizontal
                // si on peut le mettre sur l'arrière
                if (x - boatSize >= 0)
                {
                    // pour chaques cellules en partant à l'arrière du point aléatoire
                    for (int i = x; i > x - boatSize; i--)
                    {
                        // si case utilisée alors
                        if (m.GetCase(i, y).isUsed)
                        {
                            possibleBack = false;
                            break;
                            // impossible de le mettre derrière et couper la boucle
                        }

                        cases.Add(m.GetCase(i, y));
                    }
                }
                else possibleBack = false;

                // si on peut mettre le bateau sur l'avant
                if (x + boatSize <= 9)
                {
                    for (int i = x; i < x + boatSize; i++)
                    {
                        if (m.GetCase(i, y).isUsed)
                        {
                            possibleFront = false;
                            break;
                        }

                        cases.Add(m.GetCase(i, y));
                    }
                }
                else possibleFront = false;

                break;

            case 1: // Vertical
                // si on peut le mettre sur l'arrière
                if (y - boatSize >= 0)
                {
                    for (int i = y; i > y - boatSize; i--)
                    {
                        if (m.GetCase(x, i).isUsed)
                        {
                            possibleBack = false;
                            break;
                        }

                        cases.Add(m.GetCase(x, i));
                    }
                }
                else possibleBack = false;

                // si on peut mettre le bateau sur l'avant
                if (y + boatSize <= 9)
                {
                    for (int i = y; i < y + boatSize; i++)
                    {
                        if (m.GetCase(x, i).isUsed)
                        {
                            possibleFront = false;
                            break;
                        }

                        cases.Add(m.GetCase(x, i));
                    }
                }
                else possibleFront = false;

                break;
        }

        // S'il est possible de mettre le bateau sur le devant ou sur le derrière
        if (possibleBack || possibleFront)
        {
            // vérif si aucun bug dans choix de cellule 
            foreach (var cell in cases)
            {
                if (cell.isUsed)
                {
                    throw new Exception("Cell Error attention");
                }
            }

            // on vide la liste utilisée plus tôt
            cases.Clear();

            // integer Back or Front
            int bof;
            if (possibleBack && possibleFront)
            {
                bof = new Random().Next(0, 2);
            }
            else if (possibleBack)
            {
                bof = 1;
            }
            else
            {
                bof = 2;
            }


            if (bof == 1)
            {
                for (int i = 0; i < boatSize; i++)
                {
                    if (orientation == 0) // horizontal
                    {
                        cases.Add(m.GetCase(x - i, y));
                    }
                    else if (orientation == 1) // vertical
                    {
                        cases.Add(m.GetCase(x, y - i));
                    }
                }
            }
            else
            {
                for (int i = 0; i < boatSize; i++)
                {
                    if (orientation == 0)
                    {
                        cases.Add(m.GetCase(x + i, y));
                    }
                    else if (orientation == 1)
                    {
                        cases.Add(m.GetCase(x, y + i));
                    }
                }
            }

            // on créé le nouveau bateau
            Boat b = new Boat(boatSize);

            // on l'ajoute à la liste de bateaux du joueur
            p.boats.Add(b);

            foreach (var cell in cases)
            {
                cell.Boat = b;
            }
        }
        else PlaceBoatBySize(p, boatSize);
    }


    private void PlaceBoatsByPlayer()
    {
        /*
         *
         * dit cb de bateau il reste à placer
         * quelle taille pour chaque bateau
         * demander que type de bateau il veut placer
         * quelle 
         * 
         */
        // throw new NotImplementedException();
    }

    public bool touchable(int x, int y)
    {
        return !_boatMap[x, y].isTouched;
    }

    public e attack(int x, int y)
    {
        Console.WriteLine("Le bot attaque la case"+ x + " " + y);
        if (_boatMap[x, y].isUsed)
        {
            _boatMap[x, y].isTouched = true;
            _boatMap[x, y].Boat.Touch();
        }
        else
        {
            _boatMap[x, y].isTouched = true;
            return e.RIEN;
        }

        if (_boatMap[x, y].Boat.IsAlive())
            return e.TOUCHE;
        return e.COULE;
    }

    public bool boatAlive(int x, int y)
    {
        Boat b = _boatMap[x, y].Boat;
        return b.IsAlive();
    }

    public bool boatIsAlive(int x, int y)
    {
        bool alive = false;
        if (_boatMap[x, y].isUsed)
        {
            if (_boatMap[x, y].Boat.IsAlive())
            {
                alive = true;
            }
        }
        return alive;
    }
}