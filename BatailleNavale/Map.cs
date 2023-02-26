using BatailleNavale;

namespace BatailleNavale;

public class Map
{
    private Case[,] _boatMap;

    private int _boat4 = 2;
    private int _boat3 = 3;
    private int _boat2 = 4;
    private int _boat1 = 5;

    public Map()
    {
        _boatMap = new Case[10, 10];
    }

    public void InitMap()
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
                Console.Write("│ X ");
            }
        }
        else
        {
            Console.Write("│   ");
        }
    }

    public void PlaceBoats(bool isPlayer)
    {
        if (isPlayer)
            PlaceBoatsByPlayer();
        else
            PlaceBoatsAuto();
    }

    private void PlaceBoatsAuto()
    {
        Player p = Game.Bot;

        for (int i = 0; i < Game.BoatCount; i++)
        {
            int boat4 = _boat4;
            int boat3 = _boat3;
            int boat2 = _boat2;
            int boat1 = _boat1;
            /*
             *
             * if != 0 alors sinon si != 0 alors sinon...
             * utiliser le new Random().Next(min, max);
             * puis random entre 0 et 1 pour horizontal et vertical puis
             * verifier si les cases sont libres, sinon recommencer
             * 
             */
        }

        // throw new NotImplementedException();
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
}