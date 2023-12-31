/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OrkestraLib
{
    public class EventRegistry
    {
        /// <summary>
        /// List of event names and functions to process data
        /// </summary>
        private readonly ConcurrentDictionary<string, List<Action<string>>> Events;

        public EventRegistry()
        {
            Events = new ConcurrentDictionary<string, List<Action<string>>>();
        }

        public void Register(string key, List<Action<string>> actions)
        {
            if (Events.ContainsKey(key))
            {
                Events[key].Clear();
                Events[key] = actions;
            }
            else Events.TryAdd(key, actions);
        }

        /// <summary>
        /// Check if a value exists. Returns the value if found.
        /// </summary>
        public bool TryGetValue(string key, out List<Action<string>> value)
        {
            return Events.TryGetValue(key, out value);
        }

        /// <summary>
        /// Returns the value of a key or a empty list if the key does not exist
        /// </summary>
        public List<Action<string>> Get(string key)
        {
            if (TryGetValue(key, out List<Action<string>> value))
            {
                return value;
            }
            else return new List<Action<string>>();
        }

        public void Add(string key, Action<string> action)
        {
            if (Events.ContainsKey(key))
            {
                Events[key].Add(action);
            }
            else
            {
                Events.TryAdd(key, new List<Action<string>>
                {
                    action
                });
            }
        }
    }
}
