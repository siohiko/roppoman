using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSelectManager : MonoBehaviour
{
    GameObject chipSelectWindow = GameObject.Find("ChipSelectWindow");

    public void Prepare() {
      float x = 0 - (Screen.width / 2);
      chipSelectWindow.transform.position = new Vector3(x, 0, 0);

    }

    public void OpenChipSelectWindow() {

    }
}
