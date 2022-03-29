using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public string enemyTarget;

    // if bullet collides with enemy, this method will be called (Pushback) under
    // certain condition
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "Enemy"){
    //             other.gameObject.GetComponent<Enemy>().PushBack();
    //             Destroy(bulletPrefab);
    //             Debug.Log("Enemy Hit");
    //     }
    // }
    
}
