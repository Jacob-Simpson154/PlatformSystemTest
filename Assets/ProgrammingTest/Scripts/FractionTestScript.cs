using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//https://www.youtube.com/watch?v=qCghhGLUa-Y
//https://www.youtube.com/watch?v=r7VkbV0PRC8

public class FractionTestScript
{
    FractionCalculations calculation;

    void CreateReference()
    {
        calculation = new FractionCalculations();
    }

    /// <summary>
    /// Test the accuracy of fraction addition
    /// </summary>
    [Test]
    public void SingleAdditionFractionTest()
    {
        if (calculation == null)
            CreateReference();

        //      5/10    +   1/20    =   11/20
        Fraction f1 = new Fraction(5, 10);
        Fraction f2 = new Fraction(1, 20);
        Fraction f3 = calculation.Addition(f1, f2);

        Assert.AreEqual(11, f3.Numerator);
        Assert.AreEqual(20, f3.Denominator);
    }    
    
    [Test]
    public void SingleSubtractionFractionTest()
    {
        if (calculation == null)
            CreateReference();

        Fraction f1 = new Fraction(5, 10);
        Fraction f2 = new Fraction(25, 78);
        Fraction f3 = calculation.Subtraction(f1, f2);

        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(39, f3.Denominator);
    }

    [Test]
    public void SingleMultiplicationFractionTest()
    {
        if (calculation == null)
            CreateReference();

        Fraction f1 = new Fraction(12, 16);
        Fraction f2 = new Fraction(14, 27);
        Fraction f3 = calculation.Multiplication(f1, f2);

        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(18, f3.Denominator);
    }

    [Test]
    public void SingleDivideFractionTest()
    {
        if (calculation == null)
            CreateReference();

        Fraction f1 = new Fraction(14, 53);
        Fraction f2 = new Fraction(37, 75);
        Fraction f3 = calculation.Divide(f1, f2);

        Assert.AreEqual(1050, f3.Numerator);
        Assert.AreEqual(1961, f3.Denominator);
    }

}
