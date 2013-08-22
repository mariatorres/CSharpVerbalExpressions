﻿using CSharpVerbalExpressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VerbalExpressionsUnitTests
{
    [TestFixture]
    class MaybeTests
    {
        private VerbalExpressions verbEx = null;

        [Test]
        public void Maybe_WhenCalled_UsesCommonRegexUrl()
        {
            verbEx.Maybe(CommonRegex.Url);

            Assert.IsTrue(verbEx.IsMatch("http://www.google.com"), "Should match url address");
        }

        [Test]
        public void Maybe_WhenCalled_UsesCommonRegexEmail()
        {
            verbEx.Maybe(CommonRegex.Email);

            Assert.IsTrue(verbEx.IsMatch("test@github.com"), "Should match email address");
        }
    }
}
