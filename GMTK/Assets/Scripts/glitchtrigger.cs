using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchtrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject glitcControl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log(collision.collider);
        if(collision.transform.gameObject.tag == "Player") {
            glitcControl.SetActive(true);
        }
    }

    


}
