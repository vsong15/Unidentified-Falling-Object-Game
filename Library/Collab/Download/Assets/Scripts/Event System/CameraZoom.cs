using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public bool ZoomActive;
    public Vector3[] Target;
    public CinemachineVirtualCamera vcam;
    public float Speed;
    public int count;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();   
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Z)){
            count++;  
		}
        if(count%2 == 0){
            ZoomActive = true;  
		}
        else{
            ZoomActive = false;  
		}
	}

    public void LateUpdate()
    {
        if(ZoomActive){
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize,5,Speed);
            vcam.transform.position = Vector3.Lerp(vcam.transform.position,Target[1],Speed);
		}
        else{
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize,18,Speed);
            vcam.transform.position = Vector3.Lerp(vcam.transform.position,Target[0],Speed);
		}
    }
}
