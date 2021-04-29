using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool moving;
    bool bustering;
    private const float moveFreeze = 0.2f;
    private const float busterFreeze = 0.2f;
    public (int, int) index { get; set; } = (1,1);
    public GameObject busterPrefab;


    void Start() {
      moving = false;
      bustering = false;
    }


    void Update() {
      Move();
      Buster();
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

    private void Buster(){
      if(bustering){ return; }

      if(Input.GetKeyUp(KeyCode.Z)){
        bustering = true;
        StartCoroutine("BusterCoroutine");
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

    IEnumerator BusterCoroutine(){
      GameObject launchedBuster = Instantiate(busterPrefab, new Vector3( this.transform.position.x + 0.9f, this.transform.position.y - 0.15f, -1.0f), Quaternion.identity);
      Rigidbody2D busterRb = launchedBuster.GetComponent<Rigidbody2D>();
      busterRb.velocity = new Vector2(20.0f, 0.0f);
      yield return new WaitForSeconds(busterFreeze);
      bustering = false;
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
