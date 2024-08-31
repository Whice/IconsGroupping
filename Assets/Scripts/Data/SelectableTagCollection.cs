using System;
using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Набор тэгов, которые были выбраны и готовые к выбору.
    /// </summary>
    public class SelectableTagCollection
    {
        /// <summary>
        /// Выбранные тэги.
        /// </summary>
        private readonly List<TagEnum> selectedList = new List<TagEnum>();
        /// <summary>
        /// Готовые к выбору тэги.
        /// </summary>
        private readonly List<TagEnum> forChooseList = new List<TagEnum>();

        /// <summary>
        /// Выбранные тэги.
        /// </summary>
        public IReadOnlyList<TagEnum> selected=>selectedList;
        /// <summary>
        /// Готовые к выбору тэги.
        /// </summary>
        public IReadOnlyList<TagEnum> forChoose => forChooseList;
        /// <summary>
        /// Списки выбора изменились.
        /// </summary>
        public event Action selectedChanged;
        private void Sort(List<TagEnum> tags)
        {
            tags.Sort((t1, t2) => t1.GetInt() - t2.GetInt());
        }
        private void Sort()
        {
            Sort(selectedList);
            Sort(forChooseList);
        }
        /// <summary>
        /// Если нет в списке, то ничего не изменится.
        /// </summary>
        public bool TrySelect(TagEnum tag)
        {
            int index = forChooseList.IndexOf(tag);
            if(index>0)
            {
                selectedList.Add(tag);
                forChooseList.RemoveAt(index);
                Sort();
                selectedChanged?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Если нет в списке, то ничего не изменится.
        /// </summary>
        public bool TryUnselect(TagEnum tag)
        {
            int index = selectedList.IndexOf(tag);
            if(index>0)
            {
                forChooseList.Add(tag);
                selectedList.RemoveAt(index);
                Sort();
                selectedChanged?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }
        public SelectableTagCollection()
        {
            var tagsArray = Enum.GetValues(typeof(TagEnum));
            foreach (var tag in tagsArray)
            {
                forChooseList.Add((TagEnum)tag);
            }
        }
    }
}
