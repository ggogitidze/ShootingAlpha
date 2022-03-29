using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public GameObject enemy;
    // bool isHit;
    // //distance by which enemy will be thrown
    // public float push = 10.0f;
    // // Start is called before the first frame update
    // public void Death(){
    //     Destroy(gameObject);
    // }
    
    // private void OnTriggerExit2D(Collider2D other) {
    //     PushBack();
    // }
    // // changing x coordinate of enemy
    // public void PushBack(){
        
    //     enemy.transform.position += new Vector3 (enemy.transform.localScale.x * push, 0, 0);
    //     Debug.Log("Wallla");
    // }

    Rigidbody2D playerBody;
    [SerializeField] float speed;
    PlayerMovement playerMovement;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerBody = Player.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(playerBody.position.x * speed, playerBody.position.y * speed));
        Vector2 targetPosition = new Vector2(playerBody.position.x,playerBody.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}

    

