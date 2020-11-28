using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float playerJumpHeight = 3.5f;
    public GameObject groundCollider;
    public Camera mainCamera;
    private Rigidbody2D rb2d;
    private EdgeCollider2D collider;
    public float time;
    public bool repair;
    
    private float inputHorizontal;
    private float inputVertical;

    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    public int breachesRepaired;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        collider = groundCollider.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get basic movement inputs
        float moveH = Input.GetAxis ("Horizontal");
        float Jump = Input.GetAxis ("Jump");

        Vector2 movement = new Vector2(0.0f,rb2d.velocity.y);

        //Get initial jump and horizontal movement values
        movement.x = moveH * playerSpeed;

        if (groundCollider)
        {
            if (collider.IsTouchingLayers(LayerMask.GetMask("Collision")))
            {
                movement.y = Jump*playerJumpHeight;
            }
        }

        //Set rigid body velocity to input
        rb2d.velocity = movement;

        mainCamera.transform.position = new Vector3(transform.position.x,transform.position.y,-10.0f);
        
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(inputHorizontal * playerSpeed, rb2d.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null){
            if(Input.GetKey(KeyCode.W)){
               isClimbing = true;
			}  
        }
        else{
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    isClimbing = false;     
			}
		

        if(isClimbing == true && hitInfo.collider != null){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, inputVertical * playerSpeed); 
            rb2d.gravityScale = 0;
		}
        else{
            rb2d.gravityScale = 1;
		}
    }

    void Update(){     
        //Debug.Log("B Button Not Pressed");
          if(Input.GetKey(KeyCode.B)){  
              repair = true;
		  } 
          else {
              repair = false;
		  }
        if(Input.GetKeyDown(KeyCode.S)){
            rb2d.velocity = new Vector2(rb2d.velocity.x, -playerSpeed);  
		}
	}

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Breach" && repair == true){
            Destroy(other.gameObject); 
            breachesRepaired++;
            time = 0f;
		}
    }
}
