namespace BatailleNaval;

public class Coordinates
{
    private int x;
    private int y;

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinates()
    {
    }

    public int X
    {
        get { return x; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                x = value;
            }
            else
            {
                x = 0;
            }
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            if (value >= 0 && value <=10)
            {
                y = value;
            }
            else
            {
                y = 0;
            }
        }
    }
}