/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using static OrkestraLib.Utilities.ParserExtensions;

namespace OrkestraLib
{
    namespace Message
    {
        public enum StateType
        {
            UNDEFINED,
            CONNECTING,
            CONNECTED,
            DISCONNECTING,
            OPEN,
            CLOSED
        };

        public static class StateTypeExt
        {
            public static string ToJSON(this StateType me)
            {
                return me switch
                {
                    StateType.UNDEFINED => null,
                    StateType.CONNECTING => "connecting",
                    StateType.CONNECTED => "connected",
                    StateType.DISCONNECTING => "disconnecting",
                    StateType.OPEN => "open",
                    StateType.CLOSED => "closed",
                    _ => "",
                };
            }
        }

        [Serializable]
        public class State : IPacket
        {
            public KeyTypeValue[] presence;

            public State(string json)
            {
                this.InstantiateWithJSON(json);
            }

            public string FriendlyName()
            {
                return typeof(State).Name;
            }
        }
    }
}