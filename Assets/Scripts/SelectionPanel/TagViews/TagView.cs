using Assets.Scripts.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SelectionPanel.TagViews
{
    [RequireComponent(typeof(Button))]
    public class TagView:MonoBehaviour
    {
        [SerializeField] private Image Icon=null;
        [SerializeField] private TextMeshProUGUI tagName =null;

        public event Action<TagEnum> clicked;
        private Button button;
        private void Awake()
        {
            this.button = GetComponent<Button>();
            button.onClick.AddListener(() => clicked?.Invoke(type));
        }
        private TagEnum type;
        public void Initialize(TagEnum type)
        {
            this.type = type;
            Icon.gameObject.SetActive(false);
            tagName.text = type.GetName();
        }
    }
}
