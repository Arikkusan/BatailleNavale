namespace BatailleNavale;
public class Boat
{
    private int _size; // longueur du bateau (nombre de case utilisée par celui ci)
    private int _touchCount; // nombre de fois touchées

    public int Size
    {
        get { return _size;}
        set
        {
            if (value < 1)
            {
                _size = 1;
            }
            else if (value > 4)
            {
                _size = 1;
            }
            else
                _size = value;
        }
    }

    public Boat(int size)
    {
        Size = size;
        _touchCount = 0;
    }

    public void Touch()
    {
        _touchCount++;
    }

    public bool IsAlive()
    {
        return _touchCount < _size;
    }
    
    

}