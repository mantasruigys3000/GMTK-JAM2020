using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    float dir = -1;
    float spd = 5f;
    public LayerMask ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * spd * Time.deltaTime, 0, 0);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 2f,ground);
        Debug.DrawRay(transform.position, -Vector3.up*1f, Color.green);
        Debug.Log(hit.collider);

        if(hit.collider == null) {
            dir *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x * -1, 0);
        }

    }
}
