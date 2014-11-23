using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MaienM.UnityUtils.CoreEx
{
    public static class CameraEx
    {
        #region Orthographic camera
        /// <summary>
        /// Get the region shown by the camera.
        /// 
        /// Only works for orthographic cameras.
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>A vector of the extent shown by the camera</returns>
        public static Vector2 Extents(this Camera camera)
        {
            if (camera.orthographic)
            {
                return new Vector2(camera.orthographicSize * (Screen.width / Screen.height), camera.orthographicSize);
            }
            else
            {
                throw new Exception("The Extents function is not supported on non-orthographic camera's");
            }
        }

        /// <summary>
        /// Get the bounds of the camera.
        /// 
        /// Only works for orthographic cameras.
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>A rect of the region shown by the camera</returns>
        public static Rect Bounds(this Camera camera)
        {
            Vector2 extents = camera.Extents();
            Vector2 topleft = (camera.transform.position - extents.ToVector3()).ToVector2();
            return topleft.ToRectPos(extents * 2);
        }
        #endregion
    }
}
