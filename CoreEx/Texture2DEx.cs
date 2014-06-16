using UnityEngine;

namespace MaienM.UnityUtils.CoreEx
{
    /// <summary>
    /// Extension functions for 2D textures.
    /// </summary>
    static class Texture2DEx
    {
        /// <summary>
        /// Fill a texture with a color.
        /// </summary>
        /// <param name="baseText">The texture to fill</param>
        /// <param name="color">The color to fill it with</param>
        /// <returns>The modified texture</returns>
        public static Texture2D Fill(this Texture2D baseText, Color color)
        {
            return FillRect(baseText, new Rect(0, 0, baseText.width, baseText.height), color);
        }

        #region Rect
        /// <summary>
        /// Draw a colored rect onto the texture.
        /// </summary>
        /// <param name="baseText">The texture to draw on</param>
        /// <param name="drawRect">The rect to draw</param>
        /// <param name="color">The color to draw it with</param>
        /// <param name="borderWidth">The width of the drawn border</param>
        /// <returns>The modified texture</returns>
        public static Texture2D DrawRect(this Texture2D baseText, Rect drawRect, Color color, float borderWidth)
        {
            FillRect(baseText, new Rect(drawRect.xMin, drawRect.yMin, drawRect.width, borderWidth), color);
            FillRect(baseText, new Rect(drawRect.xMin, drawRect.yMax - borderWidth, drawRect.width, borderWidth), color);
            FillRect(baseText, new Rect(drawRect.xMin, drawRect.yMin, borderWidth, drawRect.height), color);
            FillRect(baseText, new Rect(drawRect.xMax - borderWidth, drawRect.yMin, borderWidth, drawRect.height), color);
            return baseText;
        }

        /// <summary>
        /// Draw a filled colored rect onto the texture.
        /// </summary>
        /// <param name="baseText">The texture to draw on</param>
        /// <param name="fillRect">The rect to draw</param>
        /// <param name="color">The color to draw it with</param>
        /// <returns>The modified texture</returns>
        public static Texture2D FillRect(this Texture2D baseText, Rect fillRect, Color color)
        {
            // Create an array of colors for the rect.
            Color[] buf = new Color[(int)fillRect.width * (int)fillRect.height];
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = color;
            }

            // Fill the area.
            baseText.SetPixels((int)fillRect.x, (int)fillRect.y, (int)fillRect.width, (int)fillRect.height, buf);
            baseText.Apply();

            return baseText;
        }

        /// <summary>
        /// Get a Rect with the same width and height as the texture.
        /// </summary>
        /// <param name="baseText">The texture to get the rect of</param>
        /// <returns>The rect</returns>
        public static Rect GetRect(this Texture2D baseText)
        {
            return new Rect(0, 0, baseText.width, baseText.height);
        }
        #endregion
    }
}