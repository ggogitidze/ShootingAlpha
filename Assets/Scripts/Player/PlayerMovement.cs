using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed;
    

    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    

    

    private void Awake() {
        //grab references from components' objects
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //flip player moving left to right
        if(horizontalInput > 0.01f){
            transform.localScale = Vector3.one;    
        }
        else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }
        //calling Jump method under the condition
        if(Input.GetKey(KeyCode.Space) && isGrounded()){
            Jump();
        }
        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        
        
    }

    //method checking if object is grounded
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    
   

}
