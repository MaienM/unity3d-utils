
namespace MaienM.UnityUtils.CoreEx
{
    /// <summary>
    /// Extension functions for rects.
    /// </summary>
    static class RectEx
    {
        /// <summary>
        /// A rect of the entire screen.
        /// </summary>
        public static Rect ScreenRect
        {
            get
            {
                return new Rect(0, 0, Screen.width, Screen.height);
            }
        }

        #region Scale
        /// <summary>
        /// Scale a Rect.
        /// </summary>
        /// <param name="baseRect">The Rect to scale</param>
        /// <param name="factor">The factor to scale the Rect with. 1 is 100 percent</param>
        /// <returns>The new Rect</returns>
        public static Rect Scale(this Rect baseRect, float factor)
        {
            Rect newRect = new Rect(baseRect);
            newRect.width *= factor;
            newRect.height *= factor;
            return newRect;
        }

        /// <summary>
        /// Changes the aspect ratio of an Rect to match that of another Rect.
        /// </summary>
        /// <param name="baseRect">The Rect to change</param>
        /// <param name="aspectRect">The Rect with the desired aspect ratio</param>
        /// <returns>The new rect</returns>
        public static Rect Aspect(this Rect baseRect, Rect aspectRect)
        {
            float currentRatio = baseRect.width / baseRect.height;
            float desiredRatio = aspectRect.width / aspectRect.height;

            Rect newRect = new Rect(baseRect);

            if (currentRatio < desiredRatio)
            {
                newRect.height = newRect.width / desiredRatio;
            }
            else if (currentRatio > desiredRatio)
            {
                newRect.width = newRect.height * desiredRatio;
            }

            return newRect;
        }
        #endregion

        #region Conversions
        /// <summary>
        /// Convert a Rect into a Vector2, using the x and y of the rect for the new Vector.
        /// </summary>
        /// <param name="rect">The Rect to convert</param>
        /// <returns>The new Vector2</returns>
        public static Vector2 ToVectorPos(this Rect rect)
        {
            return new Vector2(rect.x, rect.y);
        }

        /// <summary>
        /// Convert a Rect into a Vector2, using the width and height of the rect for the new Vector.
        /// </summary>
        /// <param name="rect">The Rect to convert</param>
        /// <returns>The new Vector2</returns>
        public static Vector2 ToVectorSize(this Rect rect)
        {
            return new Vector2(rect.width, rect.height);
        }
        #endregion

        #region Positioning
        /// <summary>
        /// Center a rect within another rect.
        /// </summary>
        /// <param name="baseRect">The rect to center</param>
        /// <param name="relativeRect">The rect to be centered</param>
        /// <returns>The centered rect</returns>
        public static Rect Center(this Rect baseRect, Rect relativeRect)
        {
            return Position(baseRect, relativeRect, GUIManager.Position.CENTER, 0.5f, 0.5f);
        }

        /// <summary>
        /// Position a rect within another rect.
        /// </summary>
        /// <param name="baseRect">The rect to position</param>
        /// <param name="relativeRect">The rect to be positioned in</param>
        /// <param name="position">The relative position of the baseRect to position on</param>
        /// <param name="xPct">The position on the x axis of the relativeRect to position the rect on</param>
        /// <param name="yPct">The position on the y axis of the relativeRect to position the rect on</param>
        /// <returns>The positioned rect</returns>
        public static Rect Position(this Rect baseRect, Rect relativeRect, Position position, int xPos, int yPos)
        {
            Rect newRect = new Rect(baseRect);

            // Position on the x axis.
            switch (position)
            {
                case GUIManager.Position.TOPLEFT:
                case GUIManager.Position.LEFT:
                case GUIManager.Position.BOTTOMLEFT:
                    newRect.x = relativeRect.x + xPos;
                    break;

                case GUIManager.Position.TOP:
                case GUIManager.Position.CENTER:
                case GUIManager.Position.BOTTOM:
                    newRect.x = relativeRect.x + xPos - baseRect.width / 2;
                    break;

                case GUIManager.Position.TOPRIGHT:
                case GUIManager.Position.RIGHT:
                case GUIManager.Position.BOTTOMRIGHT:
                    newRect.x = relativeRect.x + xPos - baseRect.width;
                    break;
            }

            // Position on the y axis.
            switch (position)
            {
                case GUIManager.Position.TOPLEFT:
                case GUIManager.Position.TOP:
                case GUIManager.Position.TOPRIGHT:
                    newRect.y = relativeRect.y + yPos;
                    break;

                case GUIManager.Position.LEFT:
                case GUIManager.Position.CENTER:
                case GUIManager.Position.RIGHT:
                    newRect.y = relativeRect.y + yPos - baseRect.height / 2;
                    break;

                case GUIManager.Position.BOTTOMLEFT:
                case GUIManager.Position.BOTTOM:
                case GUIManager.Position.BOTTOMRIGHT:
                    newRect.y = relativeRect.y + yPos - baseRect.height;
                    break;
            }

            return newRect;
        }

        /// <summary>
        /// Position a rect within another rect.
        /// </summary>
        /// <param name="baseRect">The rect to position</param>
        /// <param name="relativeRect">The rect to be positioned in</param>
        /// <param name="layout">The relative position of the baseRect to position on</param>
        /// <param name="xPct">The percentage of the x axis of the relativeRect to position the rect on</param>
        /// <param name="yPct">The percentage of the y axis of the relativeRect to position the rect on</param>
        /// <returns>The positioned rect</returns>
        public static Rect Position(this Rect baseRect, Rect relativeRect, Position layout, float xPct, float yPct)
        {
            return Position(baseRect, relativeRect, layout, (int)Math.Round(relativeRect.width * xPct, 0), (int)Math.Round(relativeRect.height * yPct, 0));
        }

        /// <summary>
        /// Move a rect.
        /// </summary>
        /// <param name="baseRect">The rect to move</param>
        /// <param name="movement">The relative movement</param>
        /// <returns>The moved rect</returns>
        public static Rect Move(this Rect baseRect, Vector2 movement)
        {
            Rect newRect = new Rect(baseRect);
            newRect.x += movement.x;
            newRect.y += movement.y;
            return newRect;
        }
        #endregion
    }
}