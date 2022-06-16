using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//https://www.youtube.com/watch?v=qCghhGLUa-Y

public class FractionTestScript
{
    /// <summary>
    /// Test the accuracy of fraction addition
    /// </summary>
    [Test]
    public void FractionTest_SingleAdditionFractionTest()
    {
        //      5/10    +   1/20    =   11/20
        Fraction f1 = new Fraction(5, 10);
        Fraction f2 = new Fraction(1, 20);
        Fraction f3 = new Fraction(f1, f2, 0);

        Assert.AreEqual(11, f3.GetNumerator());
        Assert.AreEqual(20, f3.GetDenominator());
    }    
    
    [Test]
    public void FractionTest_SingleSubtractionFractionTest()
    {
        //
        Fraction f1 = new Fraction(5, 10);
        Fraction f2 = new Fraction(25, 78);
        Fraction f3 = new Fraction(f1, f2, 1);

        Assert.AreEqual(7, f3.GetNumerator());
        Assert.AreEqual(39, f3.GetDenominator());
    }

    [Test]
    public void FractionTest_SingleMultiplicationFractionTest()
    {
        Fraction f1 = new Fraction(12, 16);
        Fraction f2 = new Fraction(14, 27);
        Fraction f3 = new Fraction(f1, f2, 2);

        Assert.AreEqual(7, f3.GetNumerator());
        Assert.AreEqual(18, f3.GetDenominator());
    }

    [Test]
    public void FractionTest_SingleDivideFractionTest()
    {
        Fraction f1 = new Fraction(14, 53);
        Fraction f2 = new Fraction(37, 75);
        Fraction f3 = new Fraction(f1, f2, 3);

        Assert.AreEqual(1050, f3.GetNumerator());
        Assert.AreEqual(1961, f3.GetDenominator());
    }
}
