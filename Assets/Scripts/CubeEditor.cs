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
    [SerializeField]
    [Range(2f, 20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.Round(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.Round(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
