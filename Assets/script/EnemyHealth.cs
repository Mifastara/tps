using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float value = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
