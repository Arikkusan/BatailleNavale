using System.Runtime.InteropServices.JavaScript;

namespace BatailleNavale;

public class Case
{
    public Boolean isTouched { get; set; }
    public Boolean isUsed { get; set; }

    public Case()
    {
        isTouched = false;
        isUsed = false;
    }
    
    
}