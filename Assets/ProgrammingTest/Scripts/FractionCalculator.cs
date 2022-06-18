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

    //Variables used as out parameters in TryParse
    //Not local values because of their frequent use
    int leftNum = 0, leftDen = 0;
    int rightNum = 0, rightDen = 0;

    FractionCalculations calculations;
    Fraction left, right, result;

    void Awake()
    {
        //Check all UI references are not null
        try
        {
            if (leftNumeratorInputField == null || leftDenominatorInputField == null 
                || rightNumeratorInputField == null || rightDenominatorInputField == null 
                || operationSelectionDropdown == null || resultText == null)
            {
                throw new System.NullReferenceException("Missing reference to one or more UI elements");
            }
        }
        catch (System.NullReferenceException)
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if an istance of calculations exists.
    /// Creates one if none exist.
    /// </summary>
    void CheckReference()
    {
        if(calculations==null)
            calculations = new FractionCalculations();
    }

    /// <summary>
    /// To be called via the calculate Buttons OnClick function
    /// </summary>
    public void CalculateFraction()
    {
        //Always check calculation exist
        CheckReference();

        //Check if all input fields have a value
        if (leftNumeratorInputField.text == "" || leftDenominatorInputField.text == "" || rightNumeratorInputField.text == "" || rightDenominatorInputField.text == "")
        {
            resultText.text = "An input is missing, check input fields";
            Debug.LogWarning("An input is missing, check input fields");
            return;
        }

        //Check if all input fields have a number entered, and not a string
        //TryParse returns true or false, and using the out parameter returns the entered integer value
        if (!int.TryParse(leftNumeratorInputField.text, out leftNum) || !int.TryParse(leftDenominatorInputField.text, out leftDen)
            || !int.TryParse(rightNumeratorInputField.text, out rightNum) || !int.TryParse(rightDenominatorInputField.text, out rightDen))
        {
            resultText.text = "Cannot convert string input into integer";
            Debug.LogWarning("Cannot convert string input into integer");
            return;
        }

        //Fractions cannot have denominators of zero
        if(leftDen != 0 && rightDen != 0)
        {
            resultText.text = "Fractions cannot have denominators of zero";
            Debug.LogWarning("Fractions cannot have denominators of zero");
            return;
        }

        //Set the Fractions to the inputed values
        left.Set(leftNum, leftDen);
        right.Set(rightNum, rightDen);

        //Try to perform the operation
        try
        {
            switch (operationSelectionDropdown.value)
            {
                case 0: result = calculations.Addition(left, right); break;
                case 1: result = calculations.Subtraction(left, right); break;
                case 2: result = calculations.Multiplication(left, right); break;
                case 3: result = calculations.Divide(left, right); break;
            }

            resultText.text = result.Numerator + " / " + result.Denominator;
        }
        //If there is a problem catch it
        catch (System.Exception)
        {
            Debug.LogError("Could not try operation, caught exception");
            throw;
        }
    }
}