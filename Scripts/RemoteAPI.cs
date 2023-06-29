/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace OrkestraLib
{
    public class RemoteAPI
    {
        public string AgentID { get; set; }

        public Func<string, Action<string>, string> On { get; set; }

        public Func<string, Action<string>, string> Off { get; set; }

        public Func<string, string, string> SetItem { get; set; }

        public Func<string, string> GetItem { get; set; }

        public Func<JObject> Capabilities { get; set; }

        public Func<List<string>> Keys { get; set; }
    }
}