using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
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
        int gridSize = waypoint.GetGridSize();
        Vector3 gridPos = waypoint.GetGridPos() * gridSize;
        transform.position = new Vector3(gridPos.x, gridPos.y, gridPos.z);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        Vector3 gridPos = waypoint.GetGridPos();
        TextMesh textMesh = gameObject.GetComponentInChildren<TextMesh>();
        string labelText = (gridPos.x).ToString("00") + "," + (gridPos.z).ToString("00");
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

}
