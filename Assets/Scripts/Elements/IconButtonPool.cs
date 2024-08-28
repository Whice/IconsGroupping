using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    internal class IconButtonPool : MonoBehaviour
    {
        [SerializeField] private IconButton iconButtonPrototype = null;

        private IconButton CreateNew()
        {
            return Instantiate(this.iconButtonPrototype);
        }
        private readonly Stack<IconButton> disableButtons = new Stack<IconButton>();
        public IconButton Pop(Sprite sprite)
        {
            if (this.disableButtons.Count == 0)
            {
                this.disableButtons.Push(CreateNew());
            }
            IconButton button = this.disableButtons.Pop();
            button.SetSprite(sprite);
            button.SetActive(true);

            return button;
        }
        public void Push(IconButton button)
        {
            button.SetActive(false);
            button.ClearParent();
            this.disableButtons.Push(button);
        }
    }
}