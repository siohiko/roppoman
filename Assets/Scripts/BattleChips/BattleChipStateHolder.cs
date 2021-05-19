using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChipStateHolder : MonoBehaviour
{

    public int[,] chipStates;

    // Start is called before the first frame update
    void Start()
    {
        chipStates = new int[5,2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
