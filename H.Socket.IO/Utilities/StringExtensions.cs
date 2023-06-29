/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Collections.Generic;

namespace H.Socket.IO.Utilities
{

    /// <summary>
    /// Extensions that work with <see langword="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Splits by indexes
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static string[] SplitByIndexes(this string text, int[] indexes)
        {
            text = text ?? throw new ArgumentNullException(nameof(text));
            indexes = indexes ?? throw new ArgumentNullException(nameof(indexes));

            var values = new List<string>();
            var lastIndex = 0;
            foreach (var index in indexes)
            {
                values.Add(text.Substring(lastIndex, index - lastIndex));

                lastIndex = index + 1;
            }

            values.Add(text.Substring(lastIndex));

            return values.ToArray();
        }
    }

}
