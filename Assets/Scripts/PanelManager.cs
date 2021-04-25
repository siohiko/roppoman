using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    
    void Awake() {
      InitPanelIndex();
      InitPanelOwner();
    }

    void Start() {}

    void Update() {}

    public void ChangePanelState() {
    }

    public void ChangePanelOwner() {
    }


    //パネルのインデックスを初期化
    private void InitPanelIndex() {
      int x = 0;
      int y = 0;

      foreach (GameObject panelObject in panels) {
        Panel panel;
        panel = panelObject.GetComponent<Panel>();
        panel.index = (x,y);

        if( x == 5 ) {
          x = 0;
          y++;
        } else {
          x++;
        }
      }
    }


    //パネルの所有者を初期化
    private void InitPanelOwner() {
      foreach (GameObject panelObject in panels) {
        Panel panel;
        panel = panelObject.GetComponent<Panel>();

        if( panel.index.Item1 <= 2) {
          panel.panelOwner = PanelOwner.Self;
        } else {
          panel.panelOwner = PanelOwner.Enemy;
        }

        Debug.Log(panel.index);
        Debug.Log(panel.panelOwner);
      }
    }

}
