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
        public enum UserEventType
        {
            Joined,
            Left,
            AgentEvent
        };

        public static class UserEventTypeExt
        {
            public static string ToJSON(this UserEventType me)
            {
                return me switch
                {
                    UserEventType.Left => "left",
                    UserEventType.AgentEvent => "agent_event",
                    UserEventType.Joined => "join",
                    _ => "",
                };
            }
        }

        [Serializable]
        public class UserEvent : IPacket
        {
            public string agentid;
            public string evt;
            public KeyValue data;

            public UserEvent(string json)
            {
                this.InstantiateWithJSON(json);
            }

            public UserEvent(string agentid, UserEventType evt)
            {
                this.agentid = agentid;
                this.evt = evt.ToJSON();

            }
            public UserEvent(string agentid, UserEventType evt, KeyValue data)
            {
                this.agentid = agentid;
                this.evt = evt.ToJSON();
                this.data = data;
            }

            public bool IsUser(string id)
            {
                return agentid.Equals(id);
            }

            public bool IsJoinEvent()
            {
                return evt.Equals(UserEventTypeExt.ToJSON(UserEventType.Joined));
            }

            public bool IsLeftEvent()
            {
                return evt.Equals(UserEventTypeExt.ToJSON(UserEventType.Left));
            }

            public bool IsPresenceEvent()
            {
                return evt.Equals(UserEventTypeExt.ToJSON(UserEventType.Joined)) ||
                       evt.Equals(UserEventTypeExt.ToJSON(UserEventType.Left));
            }

            public bool IsEvent(Type eventKey)
            {
                return data.key.Equals(eventKey.Name) && !data.value.IsSystemInitMessage();
            }

            public string FriendlyName()
            {
                return typeof(UserEvent).Name;
            }
        }
    }
}
