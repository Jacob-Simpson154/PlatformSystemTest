public class FractionCalculations
{
    /// <summary>
    /// Adds two fractions and returns the result in a fraction struct
    /// </summary>
    ///
    public void Addition(Fraction l, Fraction r, ref Fraction result)
    {
        if (l.Whole > 0) ConvertFromWhole(ref l);
        if (r.Whole > 0) ConvertFromWhole(ref r);

        result.Set(0, ((l.Numerator * r.Denominator) + (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        ReduceToLowestTerms(ref result);
    }

    /// <summary>
    /// Subtracts two fractions and returns the result in a fraction struct
    /// </summary>
    public void Subtraction(Fraction l, Fraction r, ref Fraction result)
    {
        if (l.Whole > 0) ConvertFromWhole(ref l);
        if (r.Whole > 0) ConvertFromWhole(ref r);

        result.Set(0, ((l.Numerator * r.Denominator) - (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        ReduceToLowestTerms(ref result);
    }

    /// <summary>
    /// Multiplies two fractions and returns the result in a fraction struct
    /// </summary>
    public void Multiplication(Fraction l, Fraction r, ref Fraction result)
    {
        if (l.Whole > 0) ConvertFromWhole(ref l);
        if (r.Whole > 0) ConvertFromWhole(ref r);

        result.Set(0, (l.Numerator * r.Numerator), (l.Denominator * r.Denominator));
        ReduceToLowestTerms(ref result);
    }

    /// <summary>
    /// Divides two fractions and returns the result in a fraction struct
    /// </summary>
    public void Divide(Fraction l, Fraction r, ref Fraction result)
    {
        if (l.Whole > 0) ConvertFromWhole(ref l);
        if (r.Whole > 0) ConvertFromWhole(ref r);

        int temp = r.Numerator;
        r.Numerator = r.Denominator;
        r.Denominator = temp;
        Multiplication(l, r, ref result);
    }


    /// <summary>
    /// Recursive function to find the greatest common divisor.
    /// Time Complexity Best case O(1) - only if d is divisble by n it can be over with one recursive call.
    /// Time Complexity Worst case O(log n) - when the values become a fibonachi sequence.
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
    void ReduceToLowestTerms(ref Fraction input)
    {
        int greatestCommon = GreatestCommonDivisor(input.Numerator, input.Denominator);
        input.Numerator = input.Numerator / greatestCommon;
        input.Denominator = input.Denominator / greatestCommon;
        if (input.Numerator > input.Denominator) ConvertToWhole(ref input);
    }

    void ConvertFromWhole(ref Fraction input)
    {
        input.Numerator = input.Numerator + (input.Whole * input.Denominator);
        input.Whole = 0;
    }

    void ConvertToWhole(ref Fraction input)
    {
        input.Whole = input.Numerator / input.Denominator;
        input.Numerator = input.Numerator%input.Denominator;
    }
}