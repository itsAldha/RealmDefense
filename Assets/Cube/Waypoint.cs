using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector3 gridPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector3 GetGridPos()
    {
        gridPos.x = Mathf.Round(transform.position.x / gridSize) * gridSize;
        gridPos.y = 0f;
        gridPos.z = Mathf.Round(transform.position.z / gridSize) * gridSize;
        return gridPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
