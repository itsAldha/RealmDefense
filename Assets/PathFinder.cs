using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector3, Waypoint> grid = new Dictionary<Vector3, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopcolor(Color.green);
        endWaypoint.SetTopcolor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            // Check if overlapping
            if( grid.ContainsKey(waypoint.GetGridPos()) )
                Debug.LogWarning("Overlap at " + waypoint);
            else
                grid.Add(waypoint.GetGridPos(), waypoint);
        }
        print("Loaded " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
