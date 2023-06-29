/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class RemoteAgent
    {
        OrkestraLib.RemoteAgent agent;

        [SetUp]
        public void SetupAgent()
        {
            agent = new OrkestraLib.RemoteAgent("testId");
        }

        [Test]
        public void AgentID()
        {
            Assert.That(agent.AgentID, Is.EqualTo("testId"));
        }

        [Test]
        public void UpdateValue()
        {
            Func<string, string, string, string> testUpdateValue = (string a, string b, string c) =>
            {
                Assert.That(a, Is.EqualTo("testValue"));
                return a;
            };
            agent.UpdateValue = testUpdateValue;
            Assert.That(agent.UpdateValue("testValue", "", ""), Is.EqualTo("testValue"));
        }

        [Test]
        public void UpdateMeta()
        {
            Func<string, string> testUpdateMeta = (string value) =>
            {
                Assert.That(value, Is.EqualTo("testValue"));
                return value;
            };
            agent.UpdateMeta = testUpdateMeta;
            Assert.That(agent.UpdateMeta("testValue"), Is.EqualTo("testValue"));
        }

        [Test]
        public void PublicAPI()
        {
            Assert.That(agent.AgentID, Is.EqualTo("testId"));
        }
    }
}