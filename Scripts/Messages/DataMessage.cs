/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;

namespace OrkestraLib
{
    namespace Message
    {
        [Serializable]
        public class DataMessage : Message
        {
            public string value;

            public DataMessage(string json) : base(json) { }

            public DataMessage(string sender, string data) :
                base(typeof(DataMessage).Name, sender)
            {
                this.value = data;
            }

            public override string FriendlyName()
            {
                return typeof(DataMessage).Name;
            }
        }
    }
}