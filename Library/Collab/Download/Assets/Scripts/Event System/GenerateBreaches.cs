using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBreaches : MonoBehaviour
{
    public GameObject breach;
    public int xPos;
    public int yPos;
    public int breachCount;
    public int left;
    public int right;
    public int up;
    public int down;
    public float timeDelay = 0.1f;
    public float timeRemaining;
    public bool breaches = true;
    GameObject[] numBreaches;
    public int count = 0;
    public int maxBreaches;

    void Start(){
        timeRemaining = Random.Range(4f, 15f);
	}

    void Awake(){
        numBreaches = GameObject.FindGameObjectsWithTag("Breach");
         foreach(GameObject breach in numBreaches){
            if(breach.GetComponent<Renderer>().isVisible){
                count++;     
			}  
		}
	}

    void Update(){
        if(timeRemaining > 0f){
            timeRemaining -= Time.deltaTime;
		}
        else{
            if(count < maxBreaches){
              StartCoroutine(BreachAppear());
              timeRemaining = Random.Range(4f,15f);
            }
		}
        if(timeRemaining < -1f){
            timeRemaining = 10f;   
		}
	}

    IEnumerator BreachAppear() {
        if(count < maxBreaches){
        for(int i = 0; i < breachCount; i++){
            xPos = Random.Range(left, right);
            yPos = Random.Range(up, down);
            Instantiate(breach, new Vector3(xPos, yPos, -1), Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
            count++;
		}
        }
	}
}
