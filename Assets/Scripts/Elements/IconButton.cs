using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Elements
{
    [RequireComponent(typeof(Button), typeof(Image))]
    internal class IconButton : MonoBehaviour
    {
        private Button button;
        private Image image;

        public event Action clicked;

        private void Awake()
        {
            this.button = GetComponent<Button>();
            this.image = GetComponent<Image>();
        }
        public void SetSprite(Sprite sprite)
        {
            this.image.sprite = sprite;
        }
        public void SetActive(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }
        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent, false);
        }
        public void ClearParent()
        {
            SetParent(null);
        }
    }
}