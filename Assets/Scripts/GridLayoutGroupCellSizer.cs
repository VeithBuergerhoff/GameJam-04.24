using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupCellSizer : MonoBehaviour
{
    public GridLayoutGroup layoutGroup;

    public Vector2 baseSize = new(150, 200);
    public Vector2 preferedSize = new(150, 200);
    public Vector2 preferedPadding = new(10, 10);


    void Update()
    {
        var screenSize = new Vector2(Screen.width, Screen.height); // Current screen size
        layoutGroup.cellSize = screenSize / preferedSize * baseSize;
        layoutGroup.spacing = screenSize / preferedSize * preferedPadding;
    }
}