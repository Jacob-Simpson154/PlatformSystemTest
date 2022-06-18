public struct Fraction
{
    private int whole;
    private int numerator;
    private int denominator;

    public Fraction(int w, int n, int d)
    {
        whole = w;
        numerator = n;
        denominator = d;
    }

    public void Set(int w, int n, int d)
    {
        whole = w;
        numerator = n;
        denominator = d;
    }

    public int Whole
    {
        get
        {
            return whole;
        }

        set
        {
            whole = value;
        }
    }

    public int Numerator
    {
        get
        {
            return numerator;
        }

        set
        {
            numerator = value;
        }
    }

    public int Denominator
    {
        get
        {
            return denominator;
        }

        set
        {
            denominator = value;
        }
    }
}
