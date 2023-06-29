/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Collections.Generic;

namespace OrkestraLib
{
    public class User
    {
        public string Name { get; private set; }

        public string AgentId { get; private set; }

        public string Profile { get; private set; }

        public bool Master { get; private set; }

        public Dictionary<string, string> Capacity { get; private set; }

        public string Context { get; set; }

        public User(string agentId) : this(agentId, agentId) { }

        public User(string agentId, string name = "", string profile = "")
        {
            if (string.IsNullOrWhiteSpace(agentId))
            {
                throw new ArgumentException("User: invalid agentId");
            }

            Context = "";
            AgentId = agentId;
            Name = name;
            Profile = profile;
            Capacity = new Dictionary<string, string>();
            Master = true;
        }
    }

}