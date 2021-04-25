using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelState { None }
public enum PanelOwner { Self, Enemy }

public class Panel : MonoBehaviour
{
  public (int, int) index { get; set; }
  public PanelOwner panelOwner { get; set; }
  public PanelState panelState { get; set; }

  void Awake() {}

  void Start() {}

  void Update() {}

}