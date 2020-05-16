using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        var slider = gameObject.GetComponentInChildren<Slider>();
        slider.value = HitPoints;
        if (HitPoints <= 0)
            Destroy(gameObject);
    }


}
