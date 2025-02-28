using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevOpsGuy.GUI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField]
        private CursorLockMode cursorMode;
        [SerializeField]
        private KeyCode shortcutInput;

        public KeyCode ShortcutInput => shortcutInput;
        public CursorLockMode CursorMode => cursorMode;

        public static Action OnShow;
        public static Action OnHide;

        protected UIManager manager;

        public bool IsOpen => gameObject.activeSelf;

        public virtual void Setup(UIManager manager)
        {
            this.manager = manager;
        }


        public virtual void OnShortcutPressed()
        {
            if (!gameObject.activeSelf)
                Show();
            else
                Hide();
        }

        public virtual void Show() {
            if (gameObject)
            {
                gameObject.SetActive(true);
                OnShow?.Invoke();
            }
        }

        public virtual void Hide() {
            if (gameObject)
            {
                gameObject.SetActive(false);
                OnHide?.Invoke();
            }
        }
    }
}