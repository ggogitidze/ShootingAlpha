using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void takeDamage(int damageAmount){
        currentHealth -= damageAmount;

        if(currentHealth <= 0){
            //Game Over
            anim.SetTrigger("die");
        }
    }
}
