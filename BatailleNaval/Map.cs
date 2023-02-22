namespace BatailleNaval;

public class Map
{
    private Case[,] boatMap;

    public Map()
    {
        boatMap = new Case[10, 10];
    }

    public void initMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                boatMap[i, j] = new Case();
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


        if (boatMap[i, j].isUsed)
        {
            if (boatMap[i, j].isTouched)
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
            Console.Write("│ A ");
        }
    }
}