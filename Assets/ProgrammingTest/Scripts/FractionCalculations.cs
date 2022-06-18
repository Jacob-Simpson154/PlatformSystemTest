public class FractionCalculations
{
    /// <summary>
    /// Adds two fractions and returns the result in a fraction struct
    /// </summary>
    public Fraction Addition(Fraction l, Fraction r)
    {
        Fraction result = new Fraction(((l.Numerator * r.Denominator) + (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    /// <summary>
    /// Subtracts two fractions and returns the result in a fraction struct
    /// </summary>
    public Fraction Subtraction(Fraction l, Fraction r)
    {
        Fraction result = new Fraction(((l.Numerator * r.Denominator) - (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    /// <summary>
    /// Multiplies two fractions and returns the result in a fraction struct
    /// </summary>
    public Fraction Multiplication(Fraction l, Fraction r)
    {
        Fraction result = new Fraction((l.Numerator * r.Numerator), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    /// <summary>
    /// Divides two fractions and returns the result in a fraction struct
    /// </summary>
    public Fraction Divide(Fraction l, Fraction r)
    {
        int temp = r.Numerator;
        r.Numerator = r.Denominator;
        r.Denominator = temp;
        return Multiplication(l, r);
    }


    /// <summary>
    /// Recursive function to find the greatest common divisor
    /// </summary>
    int GreatestCommonDivisor(int n, int d)
    {
        if (n == 0)
            return d;
        else return GreatestCommonDivisor(d % n, n);
    }

    /// <summary>
    /// Reduces the numerator and denominator to the lowest possible terms
    /// </summary>
    Fraction ReduceToLowestTerms(Fraction input)
    {
        int greatestCommon = GreatestCommonDivisor(input.Numerator, input.Denominator);
        input.Numerator = input.Numerator / greatestCommon;
        input.Denominator = input.Denominator / greatestCommon;
        return input;
    }
}