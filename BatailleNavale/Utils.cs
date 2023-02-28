namespace BatailleNavale;

public class Utils
{
    public static int IndexValue(String[] list, String val)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].ToUpper().Equals(val.ToUpper()))
            {
                return i;
            }
        }

        return -1;
    }
}