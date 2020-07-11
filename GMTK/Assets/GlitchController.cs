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
        yield return new WaitForSeconds(2f);
        //glitchCamFlip();
        //glitchPlayerSlow();

    }

    //Glitches
    
    void glitchCamFlip() {
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
        addText("Camera UpsideDown for 5 seconds!");
        StartCoroutine(ResetGlitchCamFlip(5f));



    }

    //Legs blow off
    void glitchPlayerSlow() {
        pl.runSpd = slowSpeed;

    }

    //Reverts

    IEnumerator ResetGlitchCamFlip(float t) {
        yield return new WaitForSeconds(t);
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
        addText("Camera Normal");


    }

    //Other
    void addText(string txt) {
        GameObject o = Instantiate(glitchText, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2)), Quaternion.identity);
        o.transform.SetParent(plCanv.transform, false);

        o.GetComponent<Text>().text = txt;

    }
}
