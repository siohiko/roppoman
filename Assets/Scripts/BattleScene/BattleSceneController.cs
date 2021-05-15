using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour {
  private Player controlPlayer;
 
      //キーと値をセットする
  public void BattleSceneControllerUpdate() {
    if(Input.GetKey(KeyCode.LeftArrow)) {
      Vector2Int v = new Vector2Int(-1,0);
      controlPlayer.MovePanel(v);
    }
    if(Input.GetKey (KeyCode.RightArrow)) {
      Vector2Int v = new Vector2Int(1,0);
      controlPlayer.MovePanel(v);
    }
    if(Input.GetKey (KeyCode.UpArrow)) {
      Vector2Int v = new Vector2Int(0,1);
      controlPlayer.MovePanel(v);
    }
    if(Input.GetKey (KeyCode.DownArrow)) {
      Vector2Int v = new Vector2Int(0,-1);
      controlPlayer.MovePanel(v);
    }
    if(Input.GetKeyUp(KeyCode.Z)) {
      controlPlayer.Buster();
    }
  }

  public void Prepare(Player player) {
    controlPlayer = player;
  }
}
