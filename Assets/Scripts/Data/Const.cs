using UnityEngine;

namespace Data
{
    public class Const
    {
        public static Vector2 PROPORTION_CANVAS_1080X1920 => _proportionCanvas1080X1920;
        private static Vector2 _proportionCanvas1080X1920 = Vector2.one;
        
        private static readonly Vector2 SCALE_CANVAS_1080X1920 = new Vector2(540, 960);
        public static float GAME_LOOP_TIME = 10;
        public static int BALLS_AMOUNT_ON_FIELD = 3;

        public Const(RectTransform canvas)
        {
            _proportionCanvas1080X1920 = new Vector2(
                canvas.transform.position.x / SCALE_CANVAS_1080X1920.x,
                canvas.transform.position.y / SCALE_CANVAS_1080X1920.y);
        }
    }
}