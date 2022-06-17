using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractionCalculator : MonoBehaviour
{
    [Header("UI variables")]
    [SerializeField] InputField leftNumeratorInputField;
    [SerializeField] InputField leftDenominatorInputField;
    [SerializeField] InputField rightNumeratorInputField;
    [SerializeField] InputField rightDenominatorInputField;
    [SerializeField] Dropdown operationSelectionDropdown;
    [SerializeField] Text resultText;

    int leftNum = 0;
    int leftDen = 0;
    int rightNum = 0;
    int rightDen = 0;


    FractionCalculations calculations;
    private void Awake()
    {
        calculations = new FractionCalculations();
    }

    /// <summary>
    /// To be called via the calculate Buttons OnClick function
    /// </summary>
    public void CalculateFraction()
    {
        if (leftNumeratorInputField.text == "" || leftDenominatorInputField.text == "" || rightNumeratorInputField.text == "" || rightDenominatorInputField.text == "")
        {
            Debug.LogError("An input is missing, check input fields");
            return;
        }

        if (!int.TryParse(leftNumeratorInputField.text, out leftNum) || !int.TryParse(leftDenominatorInputField.text, out leftDen)
            || !int.TryParse(rightNumeratorInputField.text, out rightNum) || !int.TryParse(rightDenominatorInputField.text, out rightDen))
        {
            Debug.LogError("Cannot convert string input into integer");
            return;
        }

        Fraction left = new Fraction(leftNum, leftDen);
        Fraction right = new Fraction(rightNum, rightDen);
        Fraction result = new Fraction();

        switch (operationSelectionDropdown.value)
        {
            case 0: result = calculations.Addition(left, right); break;
            case 1: result = calculations.Subtraction(left, right); break;
            case 2: result = calculations.Multiplication(left, right); break;
            case 3: result = calculations.Divide(left, right); break;
        }


        resultText.text = result.Numerator + " / " + result.Denominator;
    }
}

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