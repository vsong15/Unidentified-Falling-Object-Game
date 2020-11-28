using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{
    public GameObject[] numberOfBreaches;
    public Transform transform;
    public int speed = 10;
    public int minHeight;
    public int maxHeight;
    public float currentPosition;
    public bool destinationReached = false;
    public Rigidbody2D rb;
    public float timeLeft = 300.0f;
    public bool start = true;

    void Start(){
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        numberOfBreaches = GameObject.FindGameObjectsWithTag("Breach");
        if(!destinationReached)
            ChangePosition();

        timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             start = false;
         }
    }

    void ChangePosition(){
        currentPosition = transform.position.y;
        if(numberOfBreaches.Length > 1 && currentPosition != minHeight){    
            transform.Translate((Vector2.up * speed)/8, Space.World);
		}
        if(numberOfBreaches.Length == 0 && currentPosition != maxHeight  && start == false){
            transform.Translate((Vector2.down * speed)/8, Space.World);
		}
        if(currentPosition >= (float)maxHeight || currentPosition <= (float)minHeight){
            rb.velocity = Vector3.zero;
            destinationReached = true;
		}
	}
}
