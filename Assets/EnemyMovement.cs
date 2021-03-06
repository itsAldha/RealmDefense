﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, transform.position.y, waypoint.transform.position.z);
            //var hp = gameObject.GetComponentInChildren<Canvas>();
            //hp.transform.LookAt(GameObject.Find("Main Camera").transform); // or Camera.main.transform
            yield return new WaitForSeconds(0.5f);
        }
    }
}
