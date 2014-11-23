using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MaienM.UnityUtils.CoreEx
{
    public static class Vector3Ex
    {
        #region Conversions
        /// <summary>
        /// Connvert a Vector3 into a Vector2, dropping the z parameter.
        /// </summary>
        /// <param name="vector">The Vector3 to convert</param>
        /// <param name="z">The z value of the Vector3</param>
        /// <returns>The new Vector2</returns>
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        #endregion
    }
}
