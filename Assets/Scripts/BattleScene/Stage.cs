using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[,] panels = new GameObject[3,6];
    
    public void Prepare() {
      SetPanel();
    }

    //すでにUnity上で設置してあるパネルのgameObjectをpanelsフィールドに格納。
    public void SetPanel() {
      int i = 0;
      int j = 0;
      foreach (Transform childTransform in this.gameObject.transform){
        panels[i,j] = childTransform.gameObject;
        Panel panel = panels[i,j].GetComponent<Panel>();

        if(j < 3) {
          panel.panelOwner = PanelOwner.Self;
        } else {
          panel.panelOwner = PanelOwner.Enemy;
        }

        j++;

        if(j > 5) {
          j = 0;
          i++;
        }
      }
    }

}
