using Assets.Scripts.Elements;
using Assets.Scripts.SelectionPanel;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private SelectionPanel selectionPanel = null;
    [SerializeField] private IconButtonPool iconButtonPool = null;

    private void Start()
    {
        this.selectionPanel.Initialize(this.iconButtonPool);
    }
}
