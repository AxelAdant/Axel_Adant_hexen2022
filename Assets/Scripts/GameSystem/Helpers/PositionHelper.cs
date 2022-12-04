using BoardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Helpers
{
    public static class PositionHelper
    {
        public const int _boardRadius = 3;

        public const float TileHeight = 1f;
        public const float TileWidth = 0.75f;

        public static Position GridPosition(Vector3 worldPosition)
        {
            int q = (int)(worldPosition.x / TileWidth);

            int r = -(int)(worldPosition.z - ((-(TileHeight / 2)/ TileWidth) * worldPosition.x));

            return new Position(q, r);
        }

        public static Vector3 WorldPosition(Position gridPosition)
        {
            float x = gridPosition.Q * TileWidth;

            float z = (-(TileHeight / 2) / TileWidth) * x - gridPosition.R;

            float yPositionDefault = 0f;

            return new Vector3(x, yPositionDefault, z);
        }
    }
}
