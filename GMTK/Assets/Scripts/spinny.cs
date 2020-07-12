using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinny : MonoBehaviour
{
    // Start is called before the first frame update
    public float spd = 20f;
    public bool spinClockwise = false;
    void Start()
    {
        if (spinClockwise) {
            spd = -spd;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, 0, spd * Time.deltaTime);
    }
}
