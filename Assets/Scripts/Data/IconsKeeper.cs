using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Data
{
    internal class IconsKeeper
    {
        public readonly string iconsPath;

        public IconsKeeper(string iconsPath)
        {
            this.iconsPath = iconsPath;
        }

        public IconsKeeper()
        {

        }

        private readonly Dictionary<string, List<Sprite>> iconsbyFolders = new Dictionary<string, List<Sprite>>();

        public List<string> folders => this.iconsbyFolders.Keys.ToList();
        public List<Sprite> TryGetSprites(string folder)
        {
            if (this.iconsbyFolders.TryGetValue(folder, out List<Sprite> sprites))
                return sprites;
            else
                return null;
        }
        public void Add(string folder, List<Sprite> sprites)
        {
            this.iconsbyFolders.Add(folder, sprites);
        }
        public void Add(string folder, Sprite sprite)
        {
            if (this.iconsbyFolders.ContainsKey(folder))
            {
                this.iconsbyFolders[folder].Add(sprite);
            }
            else
            {
                this.iconsbyFolders.Add(folder, new List<Sprite>() { sprite });
            }

        }
    }
}
