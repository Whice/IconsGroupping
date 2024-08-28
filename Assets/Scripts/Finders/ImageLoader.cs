using System.IO;
using UnityEngine;

namespace Assets.Scripts.Finders
{
    internal class ImageLoader
    {
        /// <summary>
        /// Загружает изображение с указанного пути и создает из него Sprite.
        /// </summary>
        /// <param name="imagePath">Полный путь к изображению на диске.</param>
        /// <returns>Объект Sprite, созданный из загруженного изображения, или null, если загрузка не удалась.</returns>
        public static Sprite LoadSpriteFromFile(string imagePath)
        {
            // Проверяем, существует ли файл по указанному пути
            if (!File.Exists(imagePath))
            {
                Debug.LogWarning("Файл не найден: " + imagePath);
                return null;
            }

            // Загружаем изображение как массив байтов
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Создаем Texture2D из массива байтов
            Texture2D texture = new Texture2D(2, 2); // Размеры 2x2 будут заменены при загрузке
            if (texture.LoadImage(imageData))
            {
                // Создаем Sprite из Texture2D
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogWarning("Не удалось загрузить изображение из файла: " + imagePath);
                return null;
            }
        }
    }
}