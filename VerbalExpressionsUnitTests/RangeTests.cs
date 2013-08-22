﻿using CSharpVerbalExpressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VerbalExpressionsUnitTests
{
    [TestFixture]
    class RangeTests
    {
        private VerbalExpressions verbEx = null;

        [Test]
        public void Range_WhenOddNumberOfItemsInArray_ShouldAppendLastElementWithOrClause()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            string text = "abcd7sdadqascdaswde";
            object[] range = new object[3] { 1, 6, 7 };

            //Act
            verbEx.Range(range);
            //Assert
            Assert.IsTrue(verbEx.IsMatch(text));
        }

        [Test]
        public void Range_WhenOddNumberOfItemsInArray_ShouldAppendWithPipe()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            object[] range = new object[3] { 1, 6, 7 };
            string expectedExpression = "[1-6]|7";

            //Act
            verbEx.Range(range);

            //Assert
            Assert.AreEqual(expectedExpression, verbEx.ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Range_WhenNullParameterPassed_ShouldThrowArgumentNullException()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            object[] value = null;

            //Act
            //Assert
            verbEx.Range(value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Range_WhenArrayParameterHasOnlyOneValue_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            object[] value = new object[1] { 0 };

            //Act
            //Assert
            verbEx.Range(value);
        }

        [Test]
        public void Range_WhenArrayParameterHasValuesInReverseOrder_ReturnsCorrectResultForCorrectOrder()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            object[] inversedOrderArray = new object[2] { 9, 2 };
            verbEx.Range(inversedOrderArray);
            string lookupString = "testing 8 another test";

            //Act
            bool isMatch = verbEx.IsMatch(lookupString);

            //Assert
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Range_WhenArrayContainsNullParameter_ItIsIgnoredAndRemovedFromList()
        {
            //Arrange
            verbEx = VerbalExpressions.DefaultExpression;
            object[] inversedOrderArray = new object[4] { 1, null, null, 7 };
            verbEx.Range(inversedOrderArray);
            string lookupString = "testing 5 testing";

            //Act
            bool isMatch = verbEx.IsMatch(lookupString);

            //Assert
            Assert.IsTrue(isMatch);

        }
    }
}
