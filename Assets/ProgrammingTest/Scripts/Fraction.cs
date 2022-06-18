public struct Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int n, int d)
    {
        numerator = n;
        denominator = d;
    }

    public void Set(int n, int d)
    {
        numerator = n;
        denominator = d;
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
