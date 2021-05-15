using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool moving;
    bool bustering;
    private const float moveFreeze = 0.15f;
    private const float busterFreeze = 0.15f;
    public (int, int) index { get; set; } = (1,1);
    public GameObject busterPrefab;
    private Stage stage;


    public void PlayerUpdate() {
    }


    public void Prepare(Stage s) {
      moving = false;
      bustering = false;
      stage = s;
    }

    //TODO:v2は整数を想定してるよ。整数じゃなかったときの例外処理はいずれ書くよ
    public void MovePanel(Vector2 v2) {
      if(moving){ return; }

      int nextPanelX = index.Item1 + (int)v2.x;
      int nextPanelY = index.Item2 + (int)v2.y;

      //移動先のパネルが自陣であれば、プレイヤーを移動し、移動後プレイヤーのマス目座標（index）も更新
      if(stage.CheckOwnPanel(nextPanelX, nextPanelY)) {
        //ワールド内の実際のベクトルへ変換
        Vector3 v3 = v2;
        v3 = Vector3.Scale(v3, new Vector3(2.0f,1.43f,0.0f));
        moving = true;
        StartCoroutine("MoveCoroutine", v3);
        index = (nextPanelX, nextPanelY);
      }
    }

    IEnumerator MoveCoroutine(Vector3 v){
      this.transform.Translate(v);
      yield return new WaitForSeconds(moveFreeze);
      moving = false;
    }


    public void Buster(){
      if(bustering){ return; }
      bustering = true;
      StartCoroutine("BusterCoroutine");
    }

    IEnumerator BusterCoroutine(){
      GameObject launchedBuster = Instantiate(busterPrefab, new Vector3( this.transform.position.x + 0.9f, this.transform.position.y - 0.15f, -1.0f), Quaternion.identity);
      Rigidbody2D busterRb = launchedBuster.GetComponent<Rigidbody2D>();
      busterRb.velocity = new Vector2(20.0f, 0.0f);
      yield return new WaitForSeconds(busterFreeze);
      bustering = false;
    }

}
