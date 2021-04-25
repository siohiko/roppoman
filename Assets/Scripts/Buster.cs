using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : MonoBehaviour
{
  // Start is called before the first frame update
  void Start(){
    
  }

  // Update is called once per frame
  void Update(){
    if(transform.position.x > 10.0f){
        Destroy(this.gameObject);
    }
  }
  void OnCollisionEnter2D(Collision2D collision){
    collision.gameObject.GetComponent<Enemy>().hitPoint -= 1;
    Destroy(this.gameObject);
  }
}
