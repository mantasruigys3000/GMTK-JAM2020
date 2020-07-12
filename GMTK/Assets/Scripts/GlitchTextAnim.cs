using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchTextAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector2(transform.localScale.x + 2f, transform.localScale.y + 2f);
        transform.Translate(0, 100f * Time.deltaTime, 0);

        if(transform.position.y > Screen.height) {
            Destroy(gameObject);
        }
    }
}
