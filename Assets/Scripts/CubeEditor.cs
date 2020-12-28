// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the Scene is changed to a
// different Scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.

using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        string textLabel = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        gameObject.name = textLabel;
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = textLabel;
    }
}
