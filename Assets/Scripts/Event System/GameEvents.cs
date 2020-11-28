using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
	}

    public event Action<int> onWallBreach;
    public void WallBreach(int id){
        if(onWallBreach != null){
            onWallBreach(id);        
	     }
	}

    public event Action<int> offWallBreach;
    public void CloseWallBreach(int id){
        if(offWallBreach != null){
            offWallBreach(id);  
		}
	}
}
