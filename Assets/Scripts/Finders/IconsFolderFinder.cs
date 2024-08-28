using Assets.Scripts.Utils;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Finders
{
    internal class IconsFolderFinder
    {
        public readonly string iconsPath;

        public IconsFolderFinder()
        {
            this.iconsPath = Path.Combine(Application.dataPath, "Icons");
            CheckIconsFolder();
        }
        private void CheckIconsFolder()
        {
            if (!Directory.Exists(this.iconsPath))
            {
                // Если папка не существует, создаем её
                Directory.CreateDirectory(this.iconsPath);
            }
        }
        public string[] GetFolders()
        {
            string[] directories = Directory.GetDirectories(this.iconsPath);

            // Выводим названия всех папок
            foreach (string dir in directories)
            {
                string dirName = dir.GetFileName();
                Debug.Log("Найдена папка: " + dirName + " in " + dir);
            }

            return directories;
        }
    }
}
