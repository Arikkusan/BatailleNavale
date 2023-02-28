using System.Runtime.InteropServices.JavaScript;

namespace BatailleNavale;

public class Case
{
    public Boolean isTouched { get; set; }
    public Boolean isUsed { get; set; }

    private Boat _boat;

    public Boat Boat
    {
        get
        {
            return _boat;
        }
        set
        {
            if (!isUsed)
            {
                isUsed = true;
            }

            _boat = value;
        }
    }

    public Case()
    {
        isTouched = false;
        isUsed = false;
    }
    
    
}