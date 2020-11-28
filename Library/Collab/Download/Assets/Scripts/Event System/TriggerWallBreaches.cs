using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallBreaches : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider other){
        GameEvents.current.WallBreach(id);
	}

    private void OnTriggerExit(Collider other){
        GameEvents.current.CloseWallBreach(id);
	}
}
