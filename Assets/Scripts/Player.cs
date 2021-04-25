using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool moving;
    private const float moveFreeze = 0.2f;
    public (int, int) index { get; set; } = (1,1);


    void Start() {
      moving = false;
    }


    void Update() {
      Move();
    }


    private void Move() {
      if(moving){ return; }

      ((int, int), bool) newIndexInfo;

      if(Input.GetKey(KeyCode.LeftArrow)) {
        newIndexInfo = UpdateIndex(index, (-1, 0));
        if (newIndexInfo.Item2) {
          moving = true;
          index = newIndexInfo.Item1;
          StartCoroutine("MoveRight");
        }
      }
      if(Input.GetKey (KeyCode.RightArrow)) {
        newIndexInfo = UpdateIndex(index, (1, 0));
        if (newIndexInfo.Item2) {
          moving = true;
          index = newIndexInfo.Item1;
          StartCoroutine("MoveLeft");
        }
      }
      if(Input.GetKey (KeyCode.UpArrow)) {
        newIndexInfo = UpdateIndex(index, (0, -1));
        if (newIndexInfo.Item2) {
          moving = true;
          index = newIndexInfo.Item1;
          StartCoroutine("MoveUp");
        }
      }
      if(Input.GetKey (KeyCode.DownArrow)) {
        newIndexInfo = UpdateIndex(index, (0, 1));
        if (newIndexInfo.Item2) {
          moving = true;
          index = newIndexInfo.Item1;
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



    private ((int, int), bool) UpdateIndex((int, int) currentIndex, (int,int) v) {
      int x = currentIndex.Item1;
      int y = currentIndex.Item2;
      int vx = v.Item1;
      int vy = v.Item2;

      int nextX = x + vx;
      int nextY = y + vy;

      if (nextX > 2 || nextX < 0 || nextY > 2 || nextY < 0){
        return ((x, y), false);
      } else {
        return ((nextX, nextY), true);
      }
    }



}
