﻿using System;
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
    public Animator playerAnim;

    public AudioSource footstepClip;
    public AudioSource jumpClip;
    public AudioSource dieClip;
    public float runSpd = 40f;
    public bool dead = false;
    bool jump = false;
    float signDir = 1;
    public bool canShoot = true;
    public float reloadTime = 0.2f;

    float horrizontalMove = 0f;

    public GameObject currentBullet;
    public GameObject glitcControl;

    //glitchvars
    public bool switchMove = false;
    public bool noMove = false;
    public bool invis = false;

    private void Start() {
        deathText.enabled = false;

    }

    private void Update() {
       

        GetComponent<SpriteRenderer>().enabled = !invis;
        

        if(Input.GetAxisRaw("Horizontal") != 0) {
            if (!footstepClip.isPlaying) {
                footstepClip.Play();
            }
            
            playerAnim.SetBool("isRunning", true);
            signDir = Mathf.Sign(Input.GetAxisRaw("Horizontal"));

            if (switchMove) {
                signDir *= -1;
            }

        } else {
            playerAnim.SetBool("isRunning", false) ;
            footstepClip.Stop();
        }

        horrizontalMove = Input.GetAxisRaw("Horizontal") * runSpd;
        horrizontalMove = (switchMove)? horrizontalMove*-1: horrizontalMove;

        if (noMove) {
            horrizontalMove = 0f;

        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            jump = true;
        }

        if (dead) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetKey(KeyCode.Return) && canShoot) {
            canShoot = false;
            StartCoroutine(reload());

            shoot();

        }

        // cam
        cameraControl();


    }

    private void FixedUpdate() {
        controller.Move(horrizontalMove * Time.fixedDeltaTime, false, jump);
        if (jump) {
            Debug.Log("should jump");
            playerAnim.SetTrigger("jump");
            jumpClip.Play();


        }

        

        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        
        if (collision.transform.gameObject.tag == "glitchtrigger") {
            glitcControl.SetActive(true);
        }

        if (collision.transform.gameObject.tag == "princess") {
            SceneManager.LoadScene(collision.transform.gameObject.GetComponent<nextLevel>().nextScene);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(collision.transform.gameObject.GetComponent<nextLevel>().nextScene));

            
        }


        if (collision.gameObject.layer == LayerMask.NameToLayer("hazzard")) {
            die();

        }
    }

    void die() {
        //Destroy(gameObject);
        dead = true;
        deathText.enabled = true;
        playerAnim.SetTrigger("die");
        GetComponent<Rigidbody2D>().simulated = false;
        dieClip.Play();


    }

    void cameraControl() {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    void shoot() {
        Vector3 newPos = new Vector3(transform.position.x + signDir * 0.2f, transform.position.y, transform.position.z);
        GameObject o = Instantiate(currentBullet, newPos, Quaternion.identity);
        o.GetComponent<Rigidbody2D>().AddForce(new Vector2(signDir *  5f, 0), ForceMode2D.Impulse);

    }

    public void onLand() {
        playerAnim.SetTrigger("land");
        Debug.Log("Landed");
    }

    IEnumerator reload() {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

}

