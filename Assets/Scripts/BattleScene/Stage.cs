using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // panels配列にアクセスする時、インデックスはx座標,y座標の順番が逆になるので注意
    // 誤：panels[x,y]  正：panels[y,x]
    // [
    //   [Self, Self, Self, Enemy, Enemy, Enemy]
    //   [Self, Self, Self, Enemy, Enemy, Enemy]
    //   [Self, Self, Self, Enemy, Enemy, Enemy]
    // ]
    public Panel[,] panels = new Panel[3,6];
    
    
    public void Prepare() {
      SetPanel();
    }

    //すでにUnity上で設置してあるパネルのgameObjectをpanelsフィールドに格納。
    public void SetPanel() {
      GameObject[,] panelsGameObj = new GameObject[3,6];
      int i = 0;
      int j = 0;
      foreach (Transform childTransform in this.gameObject.transform){
        panelsGameObj[i,j] = childTransform.gameObject;
        panels[i,j] = panelsGameObj[i,j].GetComponent<Panel>();

        if(j < 3) {
          panels[i,j].panelOwner = PanelOwner.Self;
        } else {
          panels[i,j].panelOwner = PanelOwner.Enemy;
        }

        j++;

        if(j > 5) {
          j = 0;
          i++;
        }
      }
    }

  public bool CheckOwnPanel(int x, int y) {

    //範囲外の場合はfalse
    if (x > 5 || x < 0 || y > 2 || y < 0){
      return false;
    }

    //panels配列のインデックスはx,yの順番が逆になるので注意
    if ( panels[y,x].panelOwner == PanelOwner.Self) {
      return true;
    } else {
      return false;
    }
  }
}
