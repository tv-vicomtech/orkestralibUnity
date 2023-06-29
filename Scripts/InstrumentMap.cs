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
    public class InstrumentMap
    {
        private readonly Func<object, string> Init;
        private readonly Func<object, string> On;
        private readonly Func<object, string> Off;

        public string Value { get; set; }

        public InstrumentMap(string value)
        {
            Init = (arg) => null;
            On = (arg) => null;
            Off = (arg) => null;
            Value = value;
        }

        public InstrumentMap(string value,
                             Func<object, string> init,
                             Func<object, string> on,
                             Func<object, string> off)
        {
            Init = init;
            On = on;
            Off = off;
            Value = value;
        }

        public void InitEvent(object value)
        {
            Init?.Invoke(value);
        }

        public void OnEvent(object value)
        {
            On?.Invoke(value);
        }

        public void OffEvent(object value)
        {
            Off?.Invoke(value);
        }
    }
}