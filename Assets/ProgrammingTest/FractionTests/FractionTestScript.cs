using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FractionTestScript
{
    Fraction f1, f2, f3;
    FractionCalculations calculation;

    /// <summary>
    /// Check if an instance of calculation exists.
    /// Creates one if none exist
    /// </summary>
    void CheckReference()
    {
        if (calculation == null)
            calculation = new FractionCalculations();
    }

    /// <summary>
    /// Test the accuracy of a single addition
    /// </summary>
    [Test]
    public void SingleAdditionFractionTest()
    {
        CheckReference();

        //      5/10    +   1/20    =   11/20
        f1.Set(5, 10);
        f2.Set(1, 20);
        f3 = calculation.Addition(f1, f2);

        Assert.AreEqual(11, f3.Numerator);
        Assert.AreEqual(20, f3.Denominator);
    }    
    
    /// <summary>
    /// Test the accurary of a single subtraction
    /// </summary>
    [Test]
    public void SingleSubtractionFractionTest()
    {
        CheckReference();

        f1.Set(5, 10);
        f2.Set(25, 78);
        f3 = calculation.Subtraction(f1, f2);

        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(39, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a single multiplication
    /// </summary>
    [Test]
    public void SingleMultiplicationFractionTest()
    {
        CheckReference();

        f1.Set(12, 16);
        f2.Set(14, 27);
        f3 = calculation.Multiplication(f1, f2);

        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(18, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a single divide
    /// </summary>
    [Test]
    public void SingleDivideFractionTest()
    {
        CheckReference();

        f1.Set(14, 53);
        f2.Set(37, 75);
        f3 = calculation.Divide(f1, f2);

        Assert.AreEqual(1050, f3.Numerator);
        Assert.AreEqual(1961, f3.Denominator);
    }

}
