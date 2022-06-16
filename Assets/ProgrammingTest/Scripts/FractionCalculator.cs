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
    [SerializeField] Text result;
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
        Fraction res = new Fraction(left, right, operationSelection.value);

        result.text = res.GetNumerator() + " / " + res.GetDenominator();
    }
}