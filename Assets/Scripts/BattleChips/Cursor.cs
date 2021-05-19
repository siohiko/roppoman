using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    [SerializeField] private GameObject battleChipStateHolder;
    private BattleChipStateHolder battleChipStateHolderScript;
    public (int,int) index { get; set; } = (0,0);
    bool moving;
    private const float moveFreeze = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        battleChipStateHolderScript = battleChipStateHolder.GetComponent<BattleChipStateHolder>();
    }

    public void MoveCursor(Vector2 v2){
        if(moving){return;}

        int nextChipX = index.Item1 + (int)v2.x;
        int nextChipY = index.Item2 + (int)v2.y;
        Debug.Log("nextChipX:"+nextChipX);
        Debug.Log("nextChipY:"+nextChipY);        

        if(nextChipX < 0 || nextChipX > 4){return;}

        if(nextChipY < 0 || nextChipY > 1){return;}


        Vector3 v3 = v2;
        v3 = Vector3.Scale(v3, new Vector3(0.85f, -1.35f, 0f));
        moving = true;
        StartCoroutine("MoveCoroutine", v3);
        index = (nextChipX, nextChipY);

    }

    IEnumerator MoveCoroutine(Vector3 v){
        this.transform.Translate(v);
        yield return new WaitForSeconds(moveFreeze);
        moving = false;
    }
}
