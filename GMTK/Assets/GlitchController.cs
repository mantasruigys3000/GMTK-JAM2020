using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlitchController : MonoBehaviour
{
    
    public PlayerController pl;
    public Canvas plCanv;
    public GameObject glitchText;
    public float slowSpeed = 20f;
    public float normalSpeed = 40f;

    List<int> usedGlitches = new List<int>();
    

    // Start is called before the first frame update
    void Start()
    {
        plCanv = pl.deathText.gameObject.transform.parent.gameObject.GetComponent<Canvas>();

        
        //o.GetComponent<RectTransform>().position = new Vector2(0, 0);
        
        StartCoroutine(addGlitch());
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.dead) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }

    IEnumerator addGlitch() {
        int numGlitches = 3;
        yield return new WaitForSeconds(2f);
        //glitchCamFlip();
        //glitchPlayerSlow();
        //glitchSwitchMove();
        /*
        if (usedGlitches.Count < numGlitches) {
            int r = Random.Range(0, numGlitches - 1);

            do {
                r = Random.Range(0, numGlitches - 1);
            } while (usedGlitches.Contains(r));

            int glitch = r;

            usedGlitches.Add(glitch);

            switch (glitch) {
                case 0: glitchCamFlip(); break;
                case 1: glitchSwitchMove(); break;
                case 2: glitchPlayerSlow(); break;

            }
        }
        
        */
        StartCoroutine(addGlitch());

    }

    //Glitches
    
    void glitchCamFlip() {
        // 0
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
        addText("Camera UpsideDown for 5 seconds!");
        StartCoroutine(ResetGlitchCamFlip(5f));



    }
        
    void glitchSwitchMove() { //switch A and D 1
        
        pl.switchMove = true;
        addText("Moves Switched");
        StartCoroutine(ResetGlitchSwitchMove(5f));

        
    }

    //Legs blow off
    void glitchPlayerSlow() {
        // 2
        pl.runSpd = slowSpeed;

    }

    //Reverts

    IEnumerator ResetGlitchCamFlip(float t) {
        
        yield return new WaitForSeconds(t);
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        addText("Camera Normal");
        int g = 0;
        usedGlitches.Remove(g);


    }

    IEnumerator ResetGlitchSwitchMove(float t) {
        yield return new WaitForSeconds(t);
        pl.switchMove = false;
        addText("movement Normal");
        int g = 1;
        usedGlitches.Remove(g);


    }

    IEnumerator ResetGlitchSlowSpeed(float t) {
        yield return new WaitForSeconds(t);
        pl.runSpd = normalSpeed;
        addText("movement Normal");
        int g = 2;
        usedGlitches.Remove(g);


    }

    //Other
    void addText(string txt) {
        GameObject o = Instantiate(glitchText, Camera.main.ScreenToWorldPoint(new Vector2((Screen.width / 2) - 1, Screen.height / 2)), Quaternion.identity);
        o.transform.SetParent(plCanv.transform, false);

        o.GetComponent<Text>().text = txt;

    }
}
