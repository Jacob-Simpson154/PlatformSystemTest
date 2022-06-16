using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int n, int d)
    {
        numerator = n;
        denominator = d;
    }

    public Fraction(Fraction left, Fraction right, int op)
    {
        switch (op)
        {
            case 0:
                Addition(left, right);
                break;
            case 1:
                Subtraction(left, right);
                break;
            case 2:
                Multiplication(left, right);
                break;
            case 3:
                Divide(left, right);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Adds two fractions together and stores the result in this fraction
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    void Addition(Fraction left, Fraction right)
    {
        numerator = (left.numerator * right.denominator) + (right.numerator * left.denominator);
        denominator = left.denominator * right.denominator;
        ReduceToLowestTerms();
    }

    void Subtraction(Fraction left, Fraction right)
    {
        numerator = (left.numerator * right.denominator) - (right.numerator * left.denominator);
        denominator = left.denominator * right.denominator;
        ReduceToLowestTerms();
    }

    void Multiplication(Fraction left, Fraction right)
    {
        numerator = left.numerator * right.numerator;
        denominator = left.denominator * right.denominator;
        ReduceToLowestTerms();
    }

    void Divide(Fraction left, Fraction right)
    {
        int temp = right.numerator;
        right.numerator = right.denominator;
        right.denominator = temp;
        Multiplication(left, right);
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
    void ReduceToLowestTerms()
    {
        int greatestCommon = GreatestCommonDivisor(numerator, denominator);
        numerator = numerator / greatestCommon;
        denominator = denominator / greatestCommon;
    }

    /// <summary>
    /// Returns this fractions numerator
    /// </summary>
    public int GetNumerator()
    {
        return numerator;
    }


    /// <summary>
    /// Returns this fractions denominator
    /// </summary>
    public int GetDenominator()
    {
        return denominator;
    }
}
