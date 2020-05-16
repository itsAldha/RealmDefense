using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    public bool isExplored = false;
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector3 gridPos;
    public bool isPlaceable = true;

    private void OnMouseOver()
    {
        if( Input.GetMouseButtonDown(0) && isPlaceable )
        {
            isPlaceable = false;
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector3 GetGridPos()
    {
        gridPos.x = Mathf.Round(transform.position.x / gridSize);
        gridPos.y = 0f;
        gridPos.z = Mathf.Round(transform.position.z / gridSize);
        return gridPos;
    }

    public void SetTopcolor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
