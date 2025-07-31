using UnityEngine;

namespace ABR.Utilities
{
    using UnityEngine;
    public class InputManager : Singleton<InputManager>
    {
        public bool InputEnabled { get; set; } = true;
        public bool Key(KeyCode key)
        {
            return Input.GetKey(key) && InputEnabled;
        }

        public bool KeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key) && InputEnabled;
        }

        public bool KeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key) && InputEnabled;
        }

        public bool LeftClick()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool RightClick()
        {
            return Input.GetMouseButtonDown(1);
        }

        public bool MiddleClick()
        {
            return Input.GetMouseButtonDown(2);
        }

        public bool BackButton()
        {
            return Input.GetKeyDown(KeyCode.Backspace) && InputEnabled;
        }

        public bool NextButton()
        {
            return Input.GetKeyDown(KeyCode.Return) && InputEnabled;
        }

        public float VerticalScroll()
        {
            return Input.mouseScrollDelta.y;
        }
    }
}
