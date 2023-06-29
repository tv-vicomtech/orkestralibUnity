/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using OrkestraLib.Network;
using System;
using UnityEngine;

/// <summary>
/// Interface for the OrkestraLib main entry point
/// </summary>
public interface IOrkestra
{
    /// <summary>
    /// User-defined function to open a websocket with arbitrary libraries
    /// </summary>
    Action<string, string, Action<IWebSocketAdapter>, Action<bool>> OpenSocket { get; set; }

    /// <summary>
    /// User-defined function to close a websocket.
    /// This function is implemented by the application main controller
    /// </summary>
    Action<IWebSocketAdapter> CloseSocket { get; set; }

    string GetURL();

    GameObject GetGameObject();
}
