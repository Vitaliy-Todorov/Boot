using UnityEngine;

namespace Infrastructure
{
    public static class Helper
    {
        public static bool IsValid(this UnityEngine.Object obj)
            => obj != null && !obj.Equals(null);

        public static bool IsValid(this System.Object obj)
            => obj != null && !obj.Equals(null);

        public static bool Contains(Vector3 pointChecks, Vector3 minPosition, Vector3 maxPosition) =>
            pointChecks.x < maxPosition.x &&
            pointChecks.y < maxPosition.y && 
            pointChecks.x > minPosition.x &&
            pointChecks.y > minPosition.y;
        public static bool StrictlyContains(Vector3 pointChecks, Vector3 minPosition, Vector3 maxPosition) =>
            pointChecks.x <= maxPosition.x &&
            pointChecks.y <= maxPosition.y && 
            pointChecks.x >= minPosition.x &&
            pointChecks.y >= minPosition.y;
    }
}