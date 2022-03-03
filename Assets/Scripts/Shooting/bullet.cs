using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public string enemyTarget;

    // if bullet collides with enemy, this method will be called (Pushback) under
    // certain condition
    // private void OnTriggerEnter2D(Collider2D other) {   
    //     if(enemyTarget == "Enemy"){
    //             other.gameObject.GetComponent<Enemy>().PushBack();
    //     }        
    // }
    
}
