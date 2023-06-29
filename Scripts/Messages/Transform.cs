/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using UnityEngine;
using System;
using static OrkestraLib.Utilities.ParserExtensions;

namespace OrkestraLib
{
    namespace Message
    {
        [Serializable]
        public class Transform : IPacket
        {
            public double[] position;
            public double[] rotation;

            /// <summary>
            /// Instantiates the object from a json
            /// </summary>
            public Transform(string json) : this(Vector3.zero, Vector3.zero)
            {
                this.InstantiateWithJSON(json);
            }

            public Transform(Vector3 position, Vector3 rotation)
            {
                this.position = new double[] { position.x, position.y, position.z };
                this.rotation = new double[] { rotation.x, rotation.y, rotation.z };
            }

            public string FriendlyName()
            {
                return typeof(Transform).Name;
            }
        }
    }
}
