using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    bool isHit;
    //distance by which enemy will be thrown
    public float push = 10.0f;
    // Start is called before the first frame update
    public void Death(){
        Destroy(gameObject);
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        PushBack();
    }
    // changing x coordinate of enemy
    public void PushBack(){
        
        enemy.transform.position += new Vector3 (enemy.transform.localScale.x * push, 0, 0);
      
    }
}

    

