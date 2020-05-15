using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector3, Waypoint> grid = new Dictionary<Vector3, Waypoint>();
    Vector3[] directions = { new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0) };
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    List<Waypoint> path = new List<Waypoint>();


    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        
        while(previous != startWaypoint)
        {
            previous.isPlaceable = false;
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(previous);
        path.Reverse();
        foreach (Waypoint x in path)
            print(x);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from " + searchCenter);

            if(searchCenter == endWaypoint)
            {
                print("found it!");
                isRunning = false;
                break;
            }

            ExploreNeighbors(searchCenter);
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) return;
        print("Exploring neights for " + from);
        foreach (Vector3 direction in directions)
        {
            Vector3 neighborCoordinates = from.GetGridPos() + direction;
            if(grid.ContainsKey(neighborCoordinates))
            {
                Waypoint neighbor = grid[neighborCoordinates];
                if (neighbor.isExplored || queue.Contains(neighbor) )
                    continue;
                queue.Enqueue(neighbor);
                print("Queueing " + neighbor);
                neighbor.exploredFrom = from;
            }
        }
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
