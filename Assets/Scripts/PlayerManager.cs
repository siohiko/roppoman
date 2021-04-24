using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject panels;
    PanelManager pm;
    bool moving;
    private const float moveFreeze = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        pm = panels.GetComponent<PanelManager>();
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving){
            if(Input.GetKey (KeyCode.LeftArrow)) {
                moving = true;
                StartCoroutine("MoveRight");
            }
            if(Input.GetKey (KeyCode.RightArrow)) {
                moving = true;
                StartCoroutine("MoveLeft");
            }
            if(Input.GetKey (KeyCode.UpArrow)) {
                moving = true;
                StartCoroutine("MoveUp");
            }
            if(Input.GetKey (KeyCode.DownArrow)) {
                moving = true;
                StartCoroutine("MoveDown");
            }
        } 
    }

    IEnumerator MoveRight(){
        this.transform.Translate (-2.0f,0.0f,0.0f);
        yield return new WaitForSeconds(moveFreeze);
        moving = false;
    }
    IEnumerator MoveLeft(){
        this.transform.Translate (2.0f,0.0f,0.0f);
        yield return new WaitForSeconds(moveFreeze);
        moving = false;
    }
    IEnumerator MoveUp(){
        this.transform.Translate (0.0f,1.431f,0.0f);
        yield return new WaitForSeconds(moveFreeze);
        moving = false;
    }
    IEnumerator MoveDown(){
        this.transform.Translate (0.0f,-1.431f,0.0f);
        yield return new WaitForSeconds(moveFreeze);
        moving = false;
    }
}
