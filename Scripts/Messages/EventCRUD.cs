/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Collections.Generic;
using static OrkestraLib.Utilities.ParserExtensions;

namespace OrkestraLib
{
    namespace Message
    {
        [Serializable]
        public class EventCRUD : IPacket
        {
            public List<string> added;
            public List<string> removed;
            public List<string> updated;

            public EventCRUD(string json)
            {
                this.InstantiateWithJSON(json);
            }

            public EventCRUD(Dictionary<string, List<string>> diff)
            {
                added = diff.ContainsKey("added") ? diff["added"] : new List<string>();
                removed = diff.ContainsKey("removed") ? diff["removed"] : new List<string>();
                updated = diff.ContainsKey("updated") ? diff["updated"] : new List<string>();
            }

            public string FriendlyName()
            {
                return typeof(EventCRUD).Name;
            }
        }
    }
}
