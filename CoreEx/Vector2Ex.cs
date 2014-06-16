using UnityEngine;

namespace MaienM.UnityUtils.CoreEx
{
    /// <summary>
    /// Extension functions to for 2D vectors.
    /// </summary>
    static class Vector2Ex
    {
        #region Conversions
        /// <summary>
        /// Convert a Vector2 into a Rect, using the x and y as the position for the new Rect.
        /// </summary>
        /// <param name="baseVector">The Vector2 to convert</param>
        /// <param name="sizeVector">The Vector2 to use for the size of the new Rect</param>
        /// <returns>The new Rect</returns>
        public static Rect ToRectPos(this Vector2 positionVector, Vector2 sizeVector = new Vector2())
        {
            return new Rect(positionVector.x, positionVector.y, sizeVector.x, sizeVector.y);
        }

        /// <summary>
        /// Convert a Vector2 into a Rect, using the x and y as the size for the new Rect.
        /// </summary>
        /// <param name="baseVector">The Vector2 to convert</param>
        /// <param name="positionVector">The Vector2 to use for the position of the new Rect</param>
        /// <returns>The new Rect</returns>
        public static Rect ToRectSize(this Vector2 sizeVector, Vector2 positionVector = new Vector2())
        {
            return new Rect(positionVector.x, positionVector.y, sizeVector.x, sizeVector.y);
        }
        #endregion
    }
}