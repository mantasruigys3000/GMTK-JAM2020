using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Text deathText;
    public float runSpd = 40f;
    public bool dead = false;
    bool jump = false;
    float signDir = 1;


    float horrizontalMove = 0f;

    public GameObject currentBullet;


    private void Start() {
        deathText.enabled = false;

    }

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0) {
            signDir = Mathf.Sign(Input.GetAxisRaw("Horizontal"));

        }

        horrizontalMove = Input.GetAxisRaw("Horizontal") * runSpd;

        if (Input.GetKeyDown(KeyCode.Space)) {

            jump = true;
        }

        if (dead) {
            
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            shoot();

        }

        // cam
        cameraControl();


    }

    private void FixedUpdate() {
        controller.Move(horrizontalMove * Time.fixedDeltaTime, false, jump);
        if (jump) {
            Debug.Log("should jump");
        }

        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("hazzard")) {
            die();

        }
    }

    void die() {
        Destroy(gameObject);
        dead = true;
        deathText.enabled = true;

    }

    void cameraControl() {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    void shoot() {
        Vector3 newPos = new Vector3(transform.position.x + signDir * 0.2f, transform.position.y, transform.position.z);
        GameObject o = Instantiate(currentBullet, newPos, Quaternion.identity);
        o.GetComponent<Rigidbody2D>().AddForce(new Vector2(signDir *  5f, 0), ForceMode2D.Impulse);

    }

}

