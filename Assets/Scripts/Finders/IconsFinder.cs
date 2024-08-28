using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Finders
{
    public class IconsFinder
    {
        // Множество поддерживаемых расширений изображений
        private static readonly HashSet<string> supportedExtensions = new HashSet<string>
    {
        ".png",
        ".jpeg",
        ".jpg",
        ".bmp",
        ".gif",
        ".tiff"
    };

        /// <summary>
        /// Метод для поиска всех изображений в указанной папке.
        /// </summary>
        /// <param name="folderPath">Путь к папке для поиска изображений.</param>
        /// <returns>Массив полных путей к найденным изображениям.</returns>
        public static string[] FindAllImages(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Debug.LogWarning("Папка не найдена: " + folderPath);
                return new string[0]; // Возвращаем пустой массив, если папка не существует
            }

            List<string> imagePaths = new List<string>();

            // Получаем все файлы в указанной папке и её подкаталогах
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            // Фильтруем файлы по поддерживаемым расширениям
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                if (supportedExtensions.Contains(extension))
                {
                    imagePaths.Add(file);
                }
            }

            return imagePaths.ToArray();
        }
    }
}
