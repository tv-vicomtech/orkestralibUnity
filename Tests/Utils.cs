/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;
using System;
using OrkestraLib.Utilities;
using static OrkestraLib.Utilities.StringExtensions;

namespace Tests
{
    [TestFixture]
    public class Utils
    {

        [Test]
        public void IsCharCorrect()
        {
            var stringToCheck = StringExtensions.RandomString(5);
            Assert.That(stringToCheck.Length, Is.EqualTo(5));
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var result = stringToCheck.All(allowedChars.Contains);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckSpliceString()
        {
            List<string> auxList = new List<string>() { "a", "b", "c", "d", "e" };
            var result = auxList.Splice(2, 2);
            Assert.That(result, Is.EqualTo(new List<string>() { "c", "d" }));
            Assert.That(auxList, Is.EqualTo(new List<string>() { "a", "b", "e" }));
        }

        [Test]
        public void CheckSpliceActions()
        {
            void func1(string a) { Debug.Log(a); };
            void func2(string b) { Debug.Log(b); };
            void func3(string c) { Debug.Log(c); };
            void func4(string d) { Debug.Log(d); };
            void func5(string d) { Debug.Log(d); };

            List<Action<string>> auxList = new List<Action<string>>() { func1, func2, func3, func4, func5 };
            var result = auxList.Splice(2, 2);
            Assert.That(result, Is.EqualTo(new List<Action<string>>() { func3, func4 }));
            Assert.That(auxList, Is.EqualTo(new List<Action<string>>() { func1, func2, func5 }));
        }
    }
}
