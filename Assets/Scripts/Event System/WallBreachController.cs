using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreachController : MonoBehaviour
{
    public int id;

    void Start()
    {
        GameEvents.current.onWallBreach += OnBreach;
        GameEvents.current.onWallBreach += OffBreach;
    }

    private void OnBreach(int id){
        if(id == this.id){
        
		}
	}

    private void OffBreach(int id){
        if(id == this.id){
        
		}
	}

    private void OnDestroy(){
        GameEvents.current.onWallBreach -= OnBreach;
        GameEvents.current.onWallBreach -= OffBreach;
	}
}
