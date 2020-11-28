using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 500;
    private int currentStamina;

    public static StaminaBar instance;
    
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    private void Awake(){
        instance = this;
	}

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount){
        if(currentStamina - amount >= 0){
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
		}
        else{
              SceneManager.LoadScene("Suffocate");
		}
	}

    private IEnumerator RegenStamina(){
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina){
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
		}
        regen = null;
	}
}
