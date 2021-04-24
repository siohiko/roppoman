using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    int[,] panelState;
    enum panelStateConst
    {
        None,
        Self,
        Enemy
    } 

    // Start is called before the first frame update
    void Start()
    {
        panelState = new int[6,3]; //intの場合初期値0
        panelState[1,1] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
