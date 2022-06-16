using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractionCalculator : MonoBehaviour
{
    [SerializeField] InputField leftNumerator;
    [SerializeField] InputField leftDenominator;
    [SerializeField] InputField rightNumerator;
    [SerializeField] InputField rightDenominator;
    [SerializeField] Text resultText;
    [SerializeField] Dropdown operationSelection;

    int leftNum = 0;
    int leftDen = 0;
    int rightNum = 0;
    int rightDen = 0;


    /// <summary>
    /// To be called via the calculate Buttons OnClick function
    /// </summary>
    public void CalculateFraction()
    {
        if (leftNumerator.text == "" || leftDenominator.text == "" || leftNumerator.text == "" || rightDenominator.text == "")
        {
            Debug.LogError("An input is missing, check input fields");
            return;
        }

        if (!int.TryParse(leftNumerator.text, out leftNum) || !int.TryParse(leftDenominator.text, out leftDen)
            || !int.TryParse(rightNumerator.text, out rightNum) || !int.TryParse(rightDenominator.text, out rightDen))
        {
            Debug.LogError("Cannot convert string input into integer");
            return;
        }

        Fraction left = new Fraction(leftNum, leftDen);
        Fraction right = new Fraction(rightNum, rightDen);
        Fraction result = new Fraction();

        switch (operationSelection.value)
        {
            case 0: result = Addition(left, right);break;
            case 1: result = Subtraction(left, right);break;
            case 2: result = Multiplication(left, right);break;
            case 3: result = Divide(left, right);break;
        }


        resultText.text = result.Numerator + " / " + result.Denominator;
    }




    /// <summary>
    /// Adds two fractions together and stores the result in this fraction
    /// </summary>
    public static Fraction Addition(Fraction l, Fraction r)
    {
        Fraction result = new Fraction(((l.Numerator * r.Denominator) + (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    public static Fraction Subtraction(Fraction l, Fraction r)
    {
        Fraction result = new Fraction(((l.Numerator * r.Denominator) - (r.Numerator * l.Denominator)), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    public static Fraction Multiplication(Fraction l, Fraction r)
    {
        Fraction result = new Fraction((l.Numerator * r.Numerator), (l.Denominator * r.Denominator));
        return ReduceToLowestTerms(result);
    }

    public static Fraction Divide(Fraction l, Fraction r)
    {
        int temp = r.Numerator;
        r.Numerator = r.Denominator;
        r.Denominator = temp;
        return Multiplication(l, r);
    }


    /// <summary>
    /// Recursive function to find the greatest common divisor
    /// </summary>
    static int GreatestCommonDivisor(int n, int d)
    {
        if (n == 0)
            return d;
        else return GreatestCommonDivisor(d % n, n);
    }

    /// <summary>
    /// Reduces the numerator and denominator to the lowest possible terms
    /// </summary>
    static Fraction ReduceToLowestTerms(Fraction input)
    {
        int greatestCommon = GreatestCommonDivisor(input.Numerator, input.Denominator);
        input.Numerator = input.Numerator / greatestCommon;
        input.Denominator = input.Denominator / greatestCommon;
        return input;
    }
}