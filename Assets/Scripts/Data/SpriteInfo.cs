using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Сслыка на спрайт и всю информацию для него.
    /// </summary>
    [Serializable]
    public class SpriteInfo
    {
        [SerializeField] private Sprite spriteReference = null;
        [SerializeField] private TagEnum[] tagsList = new TagEnum[0];

        public Sprite sprite => this.spriteReference;
        private readonly HashSet<TagEnum> tagsSet;
        public HashSet<TagEnum> tags
        {
            get
            {
                if (this.tagsSet == null)
                {
                    foreach (TagEnum tag in this.tagsList)
                    {
                        this.tagsSet.Add(tag);
                    }
                }
                return this.tagsSet;
            }
        }
    }
}
