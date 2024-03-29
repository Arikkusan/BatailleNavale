﻿namespace BatailleNavale;

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
        get { return y; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                y = value;
            }
            else
            {
                y = 0;
            }
        }
    }

    public static bool IsCoordinate(string text)
    {
        bool toReturn;
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        string[] intsPossible = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        if (text.Length != 2)
        {
            toReturn = false;
        }
        else
        {
            if (letters.Contains(text[0].ToString().ToUpper()))
            {
                if (intsPossible.Contains(text[1].ToString()))
                {
                    toReturn = true;
                }
                else
                {
                    toReturn = false;
                }
            }
            else
            {
                toReturn = false;
            }
        }

        return toReturn;
    }

    public static Coordinates ConvertTextInput(String txt)
    {
        if (txt.Length == 2)
        {
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            String letter = txt[0].ToString();

            int x = Utils.IndexValue(letters, letter);
            int y = int.Parse(txt[1].ToString());
            return new Coordinates(x, y);
        }

        throw new Exception("Mauvaise longueur de text à convertir en Coordonnées, arrêt du programme");
    }

    public static String ConvertCoordinatesToText(Coordinates c)
    {
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        return letters[c.X] + c.y;
    }

    public override string ToString()
    {
        return "X : " + X + "\nY : " + Y;
    }
}