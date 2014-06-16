using UnityEngine;

namespace MaienM.UnityUtils.CoreEx
{
    /// <summary>
    /// Extension functions for rectoffsets.
    /// </summary>
    static class RectOffsetEx
    {
        /// <summary>
        /// Scale a RectOffset.
        /// </summary>
        /// <param name="baseOffset">The RectOffset to scale</param>
        /// <param name="factor">The factor to scale the RectOffset with. 1 is 100 percent</param>
        /// <returns>The scaled RectOffset</returns>
        public static RectOffset Scale(this RectOffset baseOffset, float factor)
        {
            baseOffset.top = (int)(baseOffset.top * factor);
            baseOffset.right = (int)(baseOffset.right * factor);
            baseOffset.bottom = (int)(baseOffset.bottom * factor);
            baseOffset.left = (int)(baseOffset.left * factor);
            return baseOffset;
        }

        /// <summary>
        /// Add a RectOffset to a Vector2.
        /// </summary>
        /// <param name="offset">The RectOffset to add</param>
        /// <param name="baseVector">The Vector2 to add to</param>
        /// <returns>The new Vector2</returns>
        public static Vector2 Add(this RectOffset offset, Vector2 baseVector)
        {
            Vector2 newVector = new Vector2(baseVector.x, baseVector.y);
            newVector.x += offset.horizontal;
            newVector.y += offset.vertical;
            return newVector;
        }

        /// <summary>
        /// Subtracts a RectOffset from a Vector2.
        /// </summary>
        /// <param name="offset">The RectOffset to subtract</param>
        /// <param name="baseVector">The Vector2 to subtract from</param>
        /// <returns>The new Vector2</returns>
        public static Vector2 Subtract(this RectOffset offset, Vector2 baseVector)
        {
            Vector2 newVector = new Vector2(baseVector.x, baseVector.y);
            newVector.x -= offset.horizontal;
            newVector.y -= offset.vertical;
            return newVector;
        }
    }
}