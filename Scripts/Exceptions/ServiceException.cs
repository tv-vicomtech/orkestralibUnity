/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Runtime.Serialization;

namespace OrkestraLib
{
    namespace Exceptions
    {
        [Serializable]
        public class ServiceException : Exception
        {
            public ServiceException()
            {
            }

            public ServiceException(string message) : base(message)
            {
            }

            public ServiceException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}