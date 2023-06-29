/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using NUnit.Framework;
using OrkestraLib.Message;
using OrkestraLib.Network;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class MappingService
    {
        OrkestraLib.MappingService service;

        [SetUp]
        public void SetupMappingService()
        {
            var ork = new OrkestraMock
            {
                OpenSocket = delegate (string id, string url, Action<IWebSocketAdapter> conf, Action<bool> onConnect)
                {
                    var mock = new WebSocketAdapterMock();
                    conf(mock);
                    onConnect(true);
                },

                CloseSocket = delegate (IWebSocketAdapter socket)
                {
                    socket?.Disconnect();
                }
            };

            service = new OrkestraLib.MappingService(ork);
        }

        [Test]
        public void Connect()
        {
            Assert.That(service.ReadyState, Is.EqualTo(StateType.CONNECTING));
            service.Connect("http://..", (s) => { });
            Assert.That(true, Is.EqualTo(true));
        }

        [Test]
        public void GetGroupMapping()
        {
            service.Connect("http://..", (s) => { });
            Assert.That(service.WaitingGroupPromises.Count, Is.EqualTo(0));
            service.GetGroupMapping("var", (string s) => { });
            Assert.That(service.WaitingGroupPromises.Count, Is.EqualTo(1));
        }

        [Test]
        public void InvokeCallbacks()
        {
            service.Callbacks.Add("Test", new List<Action<string>> { (s) => { } });
            service.InvokeCallbacks("Test", "test");
        }



    }
}