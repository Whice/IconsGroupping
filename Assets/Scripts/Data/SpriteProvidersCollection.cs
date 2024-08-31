using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Предоставляет ссылки на наборы спрайтов, а также возможность получать фильтрованные данные.
    /// </summary>
    public class SpriteProvidersCollection : ScriptableObject
    {
        [SerializeField] private SpritesProvider[] providers = new SpritesProvider[0];

        /// <summary>
        /// Список сортированных наборов спрайтов по тэгам.
        /// Если среди них не было найдено нужного набора тэгов, то создаётся новый фильтрованый список и добавляется сюда.
        /// </summary>
        private readonly List<FileteredSpriteInfoList> filteredLists = new List<FileteredSpriteInfoList>();

        private readonly HashSet<TagEnum> setForEquality = new HashSet<TagEnum>();
        /// <summary>
        /// Проверить на равенство значений два списка.
        /// </summary>
        private bool EqualsTagLists(TagEnum[] tl1, TagEnum[] tl2)
        {
            if (tl1 == null || tl2 == null) return false;
            if (tl1.Length != tl2.Length) return false;

            this.setForEquality.Clear();
            for (int i = 0; i < tl2.Length; i++)
                this.setForEquality.Add(tl2[i]);

            for (int i = 0; i < tl1.Length; i++)
                if (!this.setForEquality.Contains(tl1[i])) return false;

            return true;
        }
        private bool TryGetFilteredList(TagEnum[] tags, out FileteredSpriteInfoList list)
        {
            list = null;
            foreach (FileteredSpriteInfoList filtered in this.filteredLists)
            {
                if (EqualsTagLists(filtered.tags, tags))
                {
                    list = filtered;
                    return true;
                }
            }
            return false;
        }

        public FileteredSpriteInfoList GetFilteredList(TagEnum[] tags)
        {
            //Нет данных
            if (tags == null || tags.Length == 0)
            {
                return FileteredSpriteInfoList.empty;
            }
            //Удачно найдено
            else if (TryGetFilteredList(tags, out FileteredSpriteInfoList list))
            {
                return list;
            }
            //Надо создать
            else
            {
                TagEnum firstTag = tags[0];
                List<SpriteInfo> forFilter = new List<SpriteInfo>();
                foreach (SpritesProvider provider in this.providers)
                {
                    forFilter.AddRange(provider.GetByTag(firstTag));
                }

                FileteredSpriteInfoList newFiltered = new FileteredSpriteInfoList(forFilter, tags);

                this.filteredLists.Add(newFiltered);
                return newFiltered;
            }
        }
    }
}
