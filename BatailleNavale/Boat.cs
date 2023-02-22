namespace BatailleNavale;
public class Boat
{
    private int _size; // longueur du bateau (nombre de case utilisée par celui ci)
    private int _touchCount; // nombre de fois touchées
    private Coordinates _cooStart; 
    private Coordinates _cooEnd;

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
    
    public Boat(int size, Coordinates startCoo, Coordinates cooEnd)
    {
        Size = size;
        _touchCount = 0;
        this._cooStart = startCoo;
        this._cooEnd = cooEnd;
    }

    public bool IsAlive()
    {
        return _touchCount < _size;
    }
    
    

}