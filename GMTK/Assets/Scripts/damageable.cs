using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageable : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0f) {
            Destroy(gameObject);

        }
    }

    public void takeDamage(float ammount) {
        health -= ammount;

    }
}
