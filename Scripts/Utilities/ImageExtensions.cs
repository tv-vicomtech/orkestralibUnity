/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using UnityEngine;
using System.Collections;

namespace OrkestraLib
{
    namespace Utilities
    {
        public static class ImageExtensions
        {
            public static string ToBase64(this byte[] bytesArr)
            {
                return "data:image/png;base64," + Convert.ToBase64String(bytesArr);
            }

            public static byte[] Capture(this Camera camera, Rect rect)
            {
                RenderTexture rt = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 0);
                camera.targetTexture = rt;
                camera.Render();

                RenderTexture.active = rt;
                Texture2D screenShot = new Texture2D(camera.pixelWidth, camera.pixelHeight, TextureFormat.RGBA32, false);

                screenShot.ReadPixels(rect, 0, 0);
                screenShot.Apply();

                camera.targetTexture = null;
                RenderTexture.active = null;
                GameObject.Destroy(rt);

                byte[] bytes = screenShot.EncodeToPNG();
                return bytes;
            }

            public static IEnumerator ScreenshotEncode()
            {
                // wait for graphics to render
                yield return new WaitForEndOfFrame();
                string text = Camera.main.Capture(Screen.safeArea).ToBase64();
            }
        }
    }
}