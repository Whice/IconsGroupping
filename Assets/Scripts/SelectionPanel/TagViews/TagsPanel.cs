using UnityEngine;

namespace Assets.Scripts.SelectionPanel.TagViews
{
    [RequireComponent(typeof(TagViewsPool))]
    internal class TagsPanel:MonoBehaviour
    {
        private TagViewsPool tagViewsPool;


        private void Awake()
        {
            this.tagViewsPool = GetComponent<TagViewsPool>();
        }
    }
}
