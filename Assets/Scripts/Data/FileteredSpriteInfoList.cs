using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// При создании объект фильтрует данные по тегам, и сохраняет не изменяемый список для этих тэгов.
    /// </summary>
    public class FileteredSpriteInfoList
    {
        private readonly List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();
        public IReadOnlyList<SpriteInfo> sprites => this.spriteInfoList;
        public TagEnum[] tags { get; private set; }
        public FileteredSpriteInfoList(IReadOnlyList<SpriteInfo> infoForFilter, TagEnum[] tags)
        {
            this.tags = tags;
            List<SpriteInfo> notFiltered = new List<SpriteInfo>(infoForFilter);
            List<SpriteInfo> filtered = new List<SpriteInfo>();

            foreach (TagEnum tag in this.tags)
            {
                foreach (SpriteInfo nfSpriteInfo in notFiltered)
                {
                    if (nfSpriteInfo.tags.Contains(tag))
                    {
                        filtered.Add(nfSpriteInfo);
                    }
                }

                notFiltered = filtered;
                filtered = new List<SpriteInfo>();
            }

            filtered = notFiltered;//т.к. перед эти было notFiltered = filtered;
            this.spriteInfoList.AddRange(filtered);
            this.spriteInfoList.TrimExcess();
        }
        private FileteredSpriteInfoList()
        {
            this.tags = new TagEnum[0];
            this.spriteInfoList = new List<SpriteInfo>(0);
        }
        public static FileteredSpriteInfoList empty => new FileteredSpriteInfoList();
    }
}
