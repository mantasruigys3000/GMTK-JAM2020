using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> bullets = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.gameObject.tag == "enemy") {
            collision.transform.gameObject.GetComponent<damageable>().takeDamage(20f);

        }
        if (collision.transform.gameObject.tag != "Player") {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.gameObject.tag != "Player") {
            Destroy(gameObject);

        }
    }





}
