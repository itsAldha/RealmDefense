using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] GameObject towerParent;
    Queue<Tower> queueTower = new Queue<Tower>();


    public void AddTower(Waypoint baseWaypoint)
    {
        if (queueTower.Count < towerLimit)
        {
            Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
            tower.transform.parent = towerParent.transform;
            tower.baseWaypoint = baseWaypoint;
            queueTower.Enqueue(tower);
        }
        else
        {
            Tower oldtower = queueTower.Dequeue();
            oldtower.baseWaypoint.isPlaceable = true;
            oldtower.transform.position = baseWaypoint.transform.position;
            oldtower.baseWaypoint = baseWaypoint;
            queueTower.Enqueue(oldtower);
        }
    }

}
