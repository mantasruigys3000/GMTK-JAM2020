using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaky : MonoBehaviour
{
    // Start is called before the first frame update
    bool flicker = false;
    float dir = 1;
    float spd = 2f;
    void Start()
    {
        StartCoroutine(switchDir());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flicker) {
            transform.Translate(dir * spd * Time.deltaTime, 0, 0);

        }
    }

    IEnumerator switchDir() {
        yield return new WaitForSeconds(0.2f);
        dir *= -1;
        StartCoroutine(switchDir());


    }

    IEnumerator Die() {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);


    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.gameObject.tag == "Player") {
            flicker = true;
            StartCoroutine(Die());

        }
    }
}
