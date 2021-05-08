using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    Folder folder;
    Stage stage;
    Player player;
    ChipSelectManager chipSelectManager;

    void Awake(){
      prepareBattle();
      folder = new Folder();
      folder.Prepare();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
      player.PlayerUpdate();
    }
    
    void prepareBattle(){
      GameObject stageGameObj = GameObject.Find("Stage");
      stage = stageGameObj.GetComponent<Stage>();

      GameObject playerGameObj = GameObject.Find("Player");
      player = playerGameObj.GetComponent<Player>();

      chipSelectManager = new ChipSelectManager();

      chipSelectManager.Prepare();
      stage.Prepare();
      player.Prepare();
    }


}
