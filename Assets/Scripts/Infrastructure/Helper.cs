using UnityEngine;

namespace Infrastructure
{
    public static class Helper
    {
        public static bool IsValid(this UnityEngine.Object obj)
            => obj != null && !obj.Equals(null);

        public static bool IsValid(this System.Object obj)
            => obj != null && !obj.Equals(null);

        public static Vector2 BeyondBorder(Vector3 pointChecks, Vector3 minPosition, Vector3 maxPosition)
        {
            Vector2 beyondBorder = Vector2.zero;
            Vector2 distanceToMax = maxPosition - pointChecks;
            Vector2 distanceToMin =  minPosition - pointChecks;
            
            if (distanceToMax.x <= 0)
                beyondBorder.x = distanceToMax.x;
            if (distanceToMax.y <= 0)
                beyondBorder.y = distanceToMax.y;
            
            if (distanceToMin.x >= 0)
                beyondBorder.x = distanceToMin.x;
            if (distanceToMin.y >= 0)
                beyondBorder.y = distanceToMin.y;
            
            return beyondBorder;
        }

        public static bool Contains(Vector3 pointChecks, Vector3 minPosition, Vector3 maxPosition) =>
            pointChecks.x <= maxPosition.x &&
            pointChecks.y <= maxPosition.y && 
            pointChecks.x >= minPosition.x &&
            pointChecks.y >= minPosition.y;
    }
}