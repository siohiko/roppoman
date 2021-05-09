using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour
{
  public void OnClickStartButton() {
    SceneLoader sceneLoader = SceneLoader.Instance;
    sceneLoader.ChangeScene("StartScene", "Battle");
  }
}
