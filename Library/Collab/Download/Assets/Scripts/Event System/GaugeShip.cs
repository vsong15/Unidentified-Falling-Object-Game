using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeShip : MonoBehaviour
{
    public GameObject[] numberOfBreaches;
    public RectTransform rectTransform;
    public int speed = 10;
    public int minHeight;
    public int maxHeight;
    public float currentPosition;
    public bool destinationReached = false;
    public Rigidbody2D rb;
    public float timeLeft = 300.0f;
    public bool start = true;

    void Start(){
        rectTransform = GetComponent<RectTransform>();
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
        currentPosition = rectTransform.anchoredPosition.y;
        if(numberOfBreaches.Length > 1 && currentPosition != minHeight){ 
            rectTransform.Translate((Vector2.down * speed)/15, Space.World);
		}
        if(numberOfBreaches.Length == 0 && currentPosition != maxHeight  && start == false){
            rectTransform.Translate((Vector2.up * speed)/15, Space.World);
		}
        if(currentPosition >= (float)maxHeight || currentPosition <= (float)minHeight){
            rb.velocity = Vector3.zero;
            destinationReached = true;
		}
	}
}
