using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFillScript : MonoBehaviour
{
    public float maxYScale = 4.0f;
    public float targetFillPercentage = 0.0f;
    public float fillSpeed = 0.2f;
    private float fillPercentage = 0.0f;

    public FadeInScript fadeIn;
    public FadeOutScript fadeOut;

    public GameObject breachSpawner;
    public CharacterInput characterInput;
    public int count = 0;
    public int num = 0;
    public GenerateBreaches generateBreaches;
    public int start = 0;

    public bool air = false;
    public bool playerBreathingAir = false;

    void setAir(float air)
    {
        targetFillPercentage = air;
        fadeIn = GetComponent<FadeInScript>();
        fadeOut = GetComponent<FadeOutScript>();
        breachSpawner = GetComponent<GameObject>();
        characterInput = GetComponent<CharacterInput>();
        generateBreaches = GetComponent<GenerateBreaches>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(breachSpawner.transform.childCount == 1 && start == 0){
            fadeIn.startFading(); 
            air = true;
            start++;
		}
        fillPercentage = Mathf.Lerp(fillPercentage, targetFillPercentage, fillSpeed);
        if(fadeOut != null && breachSpawner.transform.childCount == 0 && generateBreaches.maxReached == true && count == 0){
            fadeOut.startFading();
            air = false;
            count++;
		}
        if(air == true && playerBreathingAir == true){
            StaminaBar.instance.UseStamina(1);    
		}
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Breach" && num == 0){
            fadeIn.startFading();  
            air = true;
            num++;
		}
        if(other.gameObject.tag == "Player"){
            playerBreathingAir = true;
		}
	}

    private void OnTriggerExit2D(Collider2D other){
         if(other.gameObject.tag == "Player"){
            playerBreathingAir = false;
		}
	}
}
