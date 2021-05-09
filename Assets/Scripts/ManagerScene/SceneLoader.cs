using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>  {
  //Awakeを使いたい場合は基底クラスのCheckInstance()を呼び出すようにしてオーバーライドしてくれんコブ。

  void Start() {
    SceneManager.LoadScene("StartScene",LoadSceneMode.Additive);
  }

  public void ChangeScene(string prevScene, string nextScene, bool unLoadAssetsFlag = true) {
    StartCoroutine(UnloadPrevScene(prevScene, unLoadAssetsFlag));
    SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
  }

  IEnumerator UnloadPrevScene(string unloadScene, bool unLoadAssetsFlag = true) {
    var op = SceneManager.UnloadSceneAsync(unloadScene);
    yield return op;

    //アンロードしたシーンの不必要なアセットを消す。（残しておきたい場合はunLoadAssetsFlagをfalseにしろ）
    if (unLoadAssetsFlag) {
      yield return Resources.UnloadUnusedAssets();
    }
  }
}
