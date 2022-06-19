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
    /// Test the accuracy of a Proper fraction addition
    /// </summary>
    [Test]
    public void AdditionFractionTest()
    {
        CheckReference();
        //      5/10    +   1/20    =   11/20
        f1.Set(0, 5, 10);
        f2.Set(0, 1, 20);
        calculation.Addition(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(11, f3.Numerator);
        Assert.AreEqual(20, f3.Denominator);
    }

    /// <summary>
    /// Test the accuracy of a Mixed fractions addition
    /// </summary>
    [Test]
    public void AdditionMixedFractionTest()
    {
        CheckReference();
        //     1 14/15    +  3 15/20    =  5 41/60
        f1.Set(1, 14, 15);
        f2.Set(3, 15, 20);
        calculation.Addition(f1, f2, ref f3);

        Assert.AreEqual(5, f3.Whole);
        Assert.AreEqual(41, f3.Numerator);
        Assert.AreEqual(60, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a Proper fraction subtraction
    /// </summary>
    [Test]
    public void SubtractionFractionTest()
    {
        CheckReference();
        //     5/10    +    25/78    =  7/39
        f1.Set(0, 5, 10);
        f2.Set(0, 25, 78);
        calculation.Subtraction(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(39, f3.Denominator);
    }


    /// <summary>
    /// Test the accurary of a Mixed fraction subtraction
    /// </summary>
    [Test]
    public void SubtractionMixedFractionTest()
    {
        CheckReference();
        //     1 3/4    +  2 3/8    =   -5/8
        f1.Set(1, 3, 4);
        f2.Set(2, 3, 8);
        calculation.Subtraction(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(-5, f3.Numerator);
        Assert.AreEqual(8, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a Proper fraction multiplication
    /// </summary>
    [Test]
    public void MultiplicationFractionTest()
    {
        CheckReference();
        //     12/16 * 14/27 = 7/18
        f1.Set(0, 12, 16);
        f2.Set(0, 14, 27);
        calculation.Multiplication(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(7, f3.Numerator);
        Assert.AreEqual(18, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a Mixed fraction multiplication
    /// </summary>
    [Test]
    public void MultiplicationMixedFractionTest()
    {
        CheckReference();
        //  3 12/16 * 12 14/27 = 46 17/18
        f1.Set(3, 12, 16);
        f2.Set(12, 14, 27);
        calculation.Multiplication(f1, f2, ref f3);

        Assert.AreEqual(46, f3.Whole);
        Assert.AreEqual(17, f3.Numerator);
        Assert.AreEqual(18, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a Proper fraction divide
    /// </summary>
    [Test]
    public void DivideFractionTest()
    {
        CheckReference();
        //  14/53 / 37/75 = 1050/1961
        f1.Set(0, 14, 53);
        f2.Set(0, 37, 75);
        calculation.Divide(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(1050, f3.Numerator);
        Assert.AreEqual(1961, f3.Denominator);
    }

    /// <summary>
    /// Test the accurary of a Mixed fraction divide
    /// </summary>
    [Test]
    public void DivideMixedFractionTest()
    {
        CheckReference();
        //   4 14/53 / 14 37/75 = 16950/57611
        f1.Set(4, 14, 53);
        f2.Set(14, 37, 75);
        calculation.Divide(f1, f2, ref f3);

        Assert.AreEqual(0, f3.Whole);
        Assert.AreEqual(16950, f3.Numerator);
        Assert.AreEqual(57611, f3.Denominator);
    }

}
