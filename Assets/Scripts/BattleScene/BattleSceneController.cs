using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour {
  private Player controlPlayer;
  private Cursor controlCursor;
 
      //キーと値をセットする
  public void BattleSceneControllerUpdate(bool isChipSelectPhase) {
    if(isChipSelectPhase){
      if(Input.GetKey(KeyCode.LeftArrow)) {
        Vector2Int v = new Vector2Int(-1,0);
        controlCursor.MoveCursor(v);
      }
      if(Input.GetKey (KeyCode.RightArrow)) {
        Vector2Int v = new Vector2Int(1,0);
        controlCursor.MoveCursor(v);
      }
      if(Input.GetKey (KeyCode.UpArrow)) {
        Vector2Int v = new Vector2Int(0,-1);
        controlCursor.MoveCursor(v);
      }
      if(Input.GetKey (KeyCode.DownArrow)) {
        Vector2Int v = new Vector2Int(0,1);
        controlCursor.MoveCursor(v);
      }
      if(Input.GetKeyUp(KeyCode.Z)) {
        //　決定ボタンのコード書こうと思ってます
      }
    }else{
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
  } 
  public void Prepare(Player player, Cursor cursor) {
    controlPlayer = player;
    controlCursor = cursor;
  }
}
