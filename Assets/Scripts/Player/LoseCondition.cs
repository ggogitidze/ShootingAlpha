using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    private Animator anim;
    public GameObject Player;
    public static float healthAmount;

    //public Rigidbody2D healthBar;
    
    private void Start() {
        //set animator parameters
        anim = GetComponent<Animator>();

        //this is for healthBar but needs to be completed
        // healthAmount = 2;
        // healthBar = GetComponent<Rigidbody2D>();
    }

    //player dies on collision with ground0
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "ground0"){
            anim.SetTrigger("die");
            Invoke("Die", 1f);
            //Invoke("ReloadScene", 0.2f);
        }
    }
    //Player's death
    void Die(){
        Destroy(Player);
    }

    //reloads scene
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
    private void Update() {
        //this is for healthBar but needs to be completed
        // if(healthAmount <= 0) Die();
    }

    // for healthBar too
    // private void OnTriggerEnter2D(Collider2D other) {
        
    //     if(other.gameObject.name.Equals("Ground")){
    //         healthAmount -= 0.3f;
    //     }
    // }
}
