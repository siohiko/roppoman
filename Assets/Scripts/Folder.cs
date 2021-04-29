using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    BattleChip[] chips = new BattleChip[30]; 

    // Start is called before the first frame update
    
    void Awake(){
        // foreach(BattleChip chip in chips){
        //     chip = new Cannon();
        // } なんかうまくいかなかった
        for(int i=0; i<30; i++){
            chips[i] = new Cannon();
        }
        Prepare();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Prepare(){
        ShuffleFolder();
    }
    void ShuffleFolder(){
        for(int i=0; i<chips.Length; i++){
            BattleChip temp = chips[i];
            int randomIndex = Random.Range(0, chips.Length);
            chips[i] = chips[randomIndex];
            chips[randomIndex] = temp;
        }   
    }
}
