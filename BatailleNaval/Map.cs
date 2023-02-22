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

    public void showMap()
    {
        Console.WriteLine("        ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
        Console.WriteLine("        │ A │ B │ C │ D │ E │ F │ G │ H │ I │ J │");
        Console.WriteLine("    ┌───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");


        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j == 0)
                {
                    Console.Write("    │ " + i + " ");
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
                    Console.Write("│   ");
                }
            }

            Console.Write("│");
            Console.WriteLine();
            if (i == 9)
            {
                Console.WriteLine("    └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            }
            else
                Console.WriteLine("    ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
        }
    }

    public static void separatingLine()
    {
        Console.WriteLine("─────────────────────────────────────────────────────");
    }
}