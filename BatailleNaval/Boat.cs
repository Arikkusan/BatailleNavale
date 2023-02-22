namespace BatailleNaval;
public class Boat
{
    private int size; // longueur du bateau (nombre de case utilisée par celui ci)
    private int touchCount; // nombre de fois touchées
    private Coordinates cooStart; 
    private Coordinates cooEnd;

    public int Size
    {
        get { return size;}
        set
        {
            if (value < 1)
            {
                size = 1;
            }
            else if (value > 4)
            {
                size = 1;
            }
            else
                size = value;
        }
    }
    
    public Boat(int size, Coordinates startCoo, Coordinates cooEnd)
    {
        Size = size;
        touchCount = 0;
        this.cooStart = startCoo;
        this.cooEnd = cooEnd;
    }

    public bool isAlive()
    {
        return touchCount < size;
    }
    
    

}