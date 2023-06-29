/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using Newtonsoft.Json;
using System.Collections.Generic;

namespace H.Engine.IO
{

    /// <summary>
    /// 
    /// </summary>
    public class EngineIoOpenMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sid")]
        public string? Sid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("upgrades")]
        public IReadOnlyList<string>? Upgrades { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pingInterval")]
        public long PingInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pingTimeout")]
        public long PingTimeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

