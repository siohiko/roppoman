using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelState { None }
public enum PanelOwner { Self, Enemy }

public class Panel : MonoBehaviour
{
  public PanelOwner panelOwner { get; set; }
  public PanelState panelState { get; set; } = PanelState.None;
}