using UnityEngine;

namespace SyndicateProject.Game.GameFlow.InputController
{
    public class InputController
    {
        
            public InputState GetInput()
            {
                var input = new InputState();

                if (TouchInput.IsSwipeLeft()) input.SwipeLeft = true;
                if (TouchInput.IsSwipeRight()) input.SwipeRight = true;
                if (TouchInput.IsSwipeUp()) input.SwipeUp = true;
                if (TouchInput.IsSwipeDown()) input.SwipeDown = true;

                return input;
            }
        
    }

    public static class TouchInput
    {
        private static Vector2 startPos;
        private static Vector2 endPos;
        private static float swipeThreshold = 50f;

        public static bool IsSwipeLeft()
        {
            return CheckSwipe(Vector2.left);
        }

        public static bool IsSwipeRight()
        {
            return CheckSwipe(Vector2.right);
        }

        public static bool IsSwipeUp()
        {
            return CheckSwipe(Vector2.up);
        }

        public static bool IsSwipeDown()
        {
            return CheckSwipe(Vector2.down);
        }

        private static bool CheckSwipe(Vector2 direction)
        {
            if (Input.touchCount == 0) return false;

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
                Vector2 delta = endPos - startPos;

                if (delta.magnitude < swipeThreshold) return false;

                delta.Normalize();
                float dot = Vector2.Dot(delta, direction);
                return dot > 0.7f;
            }
            return false;
        }
    }
    
    public class InputState
    {
        public bool SwipeLeft;
        public bool SwipeRight;
        public bool SwipeUp;
        public bool SwipeDown;
    }
}