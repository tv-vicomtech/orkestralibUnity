/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class User
    {
        OrkestraLib.User user;

        [SetUp]
        public void SetupUser()
        {
            user = new OrkestraLib.User("idVal", "nameVal", "profileVal");
        }

        [Test]
        public void IsMaster()
        {
            Assert.That(user.Master, Is.EqualTo(true));
        }

        [Test]
        public void AgentId()
        {
            Assert.That(user.AgentId, Is.EqualTo("idVal"));
        }

        [Test]
        public void Name()
        {
            Assert.That(user.Name, Is.EqualTo("nameVal"));
        }

        [Test]
        public void Profile()
        {
            Assert.That(user.Profile, Is.EqualTo("profileVal"));
        }
    }
}