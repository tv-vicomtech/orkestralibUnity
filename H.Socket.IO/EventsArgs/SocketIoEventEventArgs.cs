/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
namespace H.Socket.IO.EventsArgs
{

    /// <summary>
    /// Arguments used in <see cref="SocketIoClient.EventReceived"/> event
    /// </summary>
    public class SocketIoEventEventArgs : SocketIoEventArgs
    {
        /// <summary>
        /// IsHandled
        /// </summary>
        public bool IsHandled { get; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="namespace"></param>
        /// <param name="isHandled"></param>
        public SocketIoEventEventArgs(string value, string @namespace, bool isHandled) :
            base(value, @namespace)
        {
            IsHandled = isHandled;
        }
    }

}
