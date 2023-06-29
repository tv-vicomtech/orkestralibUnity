/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using OrkestraLib.Message;
using UnityEngine;
using static OrkestraLib.Utilities.ParserExtensions;

namespace OrkestraLib.Network
{
    public class WebSocketAdapterMock : IWebSocketAdapter
    {
        private string url;
        public int requests;

        public WebSocketAdapterMock()
        {
            requests = 0;
        }

        public void Connect(string url)
        {
            this.url = url;
        }

        public void Connect(string url, Action<IWebSocketAdapter> config, Action<bool> onConnect)
        {
            this.url = url;
        }

        public void Disconnect()
        {
            requests = 0;
        }

        public void Emit(string evtKey, string data)
        {
            requests++;
        }

        public string GetURL()
        {
            return url;
        }

        public void On(string evtKey, Action<string> callback)
        {
        }

        public bool IsConnected()
        {
            return true;
        }

        public void Emit(string evtKey, IPacket data)
        {
            Emit(evtKey, data.ToJSON());
        }

    }
}
