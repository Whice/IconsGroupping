using Assets.Scripts.Elements;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SelectionPanel
{
    internal class SelectionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdown = null;
        [SerializeField] private Transform elementsParent = null;

        private IconButtonPool iconButtonPool;

        private readonly List<IconButton> buttons = new List<IconButton>();
        private readonly List<string> foldersNames = new List<string>();
        /// <summary>
        /// Очищает все текущие элементы в Dropdown и добавляет новые элементы из списка.
        /// </summary>
        /// <param name="dropdown">Dropdown, который нужно обновить.</param>
        /// <param name="newOptions">Список строк для добавления в Dropdown.</param>
        public void UpdateDropdownOptions(List<string> newOptions)
        {
            bool isOkData = true;
            if (this.dropdown == null)
            {
                Debug.LogError("Dropdown не должен быть null.");
                isOkData = false;
            }

            if (newOptions == null || newOptions.Count == 0)
            {
                Debug.LogWarning("Список newOptions пуст или не инициализирован.");
                isOkData = false;
            }

            // Очищаем существующие опции в Dropdown
            this.dropdown.ClearOptions();

            if (isOkData)
            {
                // Добавляем новые опции в Dropdown
                this.dropdown.AddOptions(newOptions);

                Debug.Log("Dropdown обновлен новыми значениями.");
            }
        }
        public void UpdateIcons()
        {
            List<Sprite> sprites = null;//ToDo: заполнить 

            foreach (IconButton button in this.buttons)
            {
                this.iconButtonPool.Push(button);
            }
            this.buttons.Clear();

            foreach (Sprite sprite in sprites)
            {
                IconButton button = this.iconButtonPool.Pop(sprite);
                this.buttons.Add(button);
                button.SetParent(this.elementsParent);
            }
        }

        public void Initialize(IconButtonPool iconButtonPool)
        {
            this.iconButtonPool = iconButtonPool;

            UpdateDropdownOptions(this.foldersNames.Select((fullName) => fullName.GetFileName()).ToList());

            UpdateIcons();
            this.dropdown.onValueChanged.AddListener((_) => UpdateIcons());
        }
    }
}