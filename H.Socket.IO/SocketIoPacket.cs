/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Linq;
namespace H.Socket.IO
{
    internal class SocketIoPacket
    {
        #region Constants

        public const string ConnectPrefix = "0";
        public const string DisconnectPrefix = "1";
        public const string EventPrefix = "2";
        //public const string AckPrefix = "3";
        public const string ErrorPrefix = "4";
        //public const string BinaryEventPrefix = "5";
        //public const string BinaryAckPrefix = "6";

        public const string DefaultNamespace = "/";

        #endregion

        #region Properties

        public string Prefix { get; set; }
        public string Namespace { get; set; }
        public string Value { get; set; }

        #endregion

        #region Constructors

        public SocketIoPacket(string prefix, string? value = null, string? @namespace = null)
        {
            Prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            Namespace = @namespace ?? DefaultNamespace;
            Value = value ?? string.Empty;
        }

        #endregion

        #region Public methods

        public static SocketIoPacket Decode(string message)
        {
            var prefix = message.Substring(0, 1);
            if (message.ElementAtOrDefault(1) == '/')
            {
                var index = message.IndexOf(",", StringComparison.OrdinalIgnoreCase);
                var @namespace = index >= 0
                    ? message.Substring(1, index - 1)
                    : message.Substring(1);
                var value = index >= 0
                    ? message.Substring(index + 1)
                    : string.Empty;

                return new SocketIoPacket(prefix, value, @namespace);
            }

            return new SocketIoPacket(prefix, message.Substring(1));
        }

        public string Encode()
        {
            var namespaceBody = Namespace == DefaultNamespace
                ? string.Empty
                : $"/{Namespace.TrimStart('/')}";
            namespaceBody += !string.IsNullOrWhiteSpace(namespaceBody) && !string.IsNullOrWhiteSpace(Value)
                ? ","
                : string.Empty;

            return $"{Prefix}{namespaceBody}{Value}";
        }

        #endregion
    }

}

