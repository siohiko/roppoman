using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BattleChip
{
    public string name { get; set; }
    public string code { get; set; }
    public int damage { get; set; }
    public int attribute { get; set; }
    public Sprite image { get; set; }
    public bool timeStop { get; set; }

    public void Awake();
    public void Start();
    public void Update();
    public void Use();
}
