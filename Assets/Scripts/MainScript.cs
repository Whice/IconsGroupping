using Assets.Scripts.Data;
using Assets.Scripts.Elements;
using Assets.Scripts.Finders;
using Assets.Scripts.SelectionPanel;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private SelectionPanel selectionPanel = null;
    [SerializeField] private IconButtonPool iconButtonPool = null;

    private void Start()
    {
        IconsFolderFinder finder = new IconsFolderFinder();
        IconsKeeper keeper = new IconsKeeper(finder.iconsPath);

        foreach (string folder in finder.GetFolders())
        {
            foreach (string iconPath in IconsFinder.FindAllImages(folder))
            {
                keeper.Add(folder, ImageLoader.LoadSpriteFromFile(iconPath));
            }
        }

        this.selectionPanel.Initialize(keeper, this.iconButtonPool);
    }
}
