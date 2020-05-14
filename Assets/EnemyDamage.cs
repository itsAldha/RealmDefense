using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int HitPoints;
    // Start is called before the first frame update
    void Start()
    {
        HitPoints = 10;
    }

    private void OnParticleCollision(GameObject other)
    {
        HitPoints -= 1;
        if (HitPoints <= 0)
            Destroy(gameObject);
    }


}
