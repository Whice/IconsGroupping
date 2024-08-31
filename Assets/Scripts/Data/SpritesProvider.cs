using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Предоставляет набор ссылок на спрайты из редактора.
    /// </summary>
    public class SpritesProvider : ScriptableObject
    {
        [SerializeField] private SpriteInfo[] spritesList = new SpriteInfo[0];

        public SpriteInfo[] sprites => this.spritesList;
        public IReadOnlyList<SpriteInfo> GetByTag(TagEnum tag)
        {
            List<SpriteInfo> returnedList = new List<SpriteInfo>(50);
            foreach (SpriteInfo info in this.spritesList)
            {
                if (info.tags.Contains(tag))
                {
                    returnedList.Add(info);
                }
            }
            return returnedList;
        }
    }
}
