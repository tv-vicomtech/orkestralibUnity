/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using UnityEngine;
using static OrkestraLib.Utilities.ParserExtensions;

namespace OrkestraLib
{
    namespace Message
    {
        [Serializable]
        public class KeyValue : IPacket, IKeyValue
        {
            public string key;
            public string value;

            public KeyValue()
            {
                key = "";
                value = "";
            }

            public KeyValue(string json)
            {
                this.InstantiateWithJSON(json);
            }

            public KeyValue(string key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public KeyValue(KeyValueType key, string value)
            {
                this.key = key.ToJSON();
                this.value = value;
            }

            public string StringVal()
            {
                return value;
            }

            public string[] ListVal()
            {
                return new string[] { value };
            }

            public bool IsEvent(Type expected)
            {
                // init1 is an hardcoded message in orkestralib
                return key.Equals(expected.Name) && !value.IsSystemInitMessage();
            }

            public bool ValueEquals(string v)
            {
                return value.Equals(v);
            }

            public virtual string FriendlyName()
            {
                return typeof(KeyValue).Name;
            }
        }
    }
}
