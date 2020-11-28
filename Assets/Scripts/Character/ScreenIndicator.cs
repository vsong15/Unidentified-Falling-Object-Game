using UnityEngine;
using System.Collections;

public class ScreenIndicator : MonoBehaviour {

public Texture2D icon; 
public float iconSize = 50f;
[HideInInspector]
public GUIStyle gooey;
Vector2 indRange;
float scaleRes = Screen.width / 500; 

Camera cam;
bool visible = true;

void Start () {
	visible = GetComponent<SpriteRenderer> ().isVisible;

	cam = Camera.main; 

	indRange.x = Screen.width - (Screen.width / 6);
	indRange.y = Screen.height - (Screen.height / 7);
	indRange /= 2f;

	gooey.normal.textColor = new Vector4 (0, 0, 0, 0); 
}

void OnGUI () {
	if (!visible) {
		Vector3 dir = transform.position - cam.transform.position;
		dir = Vector3.Normalize (dir);
		dir.y *= -1f;

		Vector2 indPos = new Vector2 (indRange.x * dir.x, indRange.y * dir.y);
		indPos = new Vector2 ((Screen.width / 2) + indPos.x,
	                      (Screen.height / 2) + indPos.y);

		Vector3 pdir = transform.position - cam.ScreenToWorldPoint(new Vector3(indPos.x, indPos.y,
		                                                                        transform.position.z));
		pdir = Vector3.Normalize(pdir);

		float angle = Mathf.Atan2(pdir.x, pdir.y) * Mathf.Rad2Deg;

		GUIUtility.RotateAroundPivot(angle, indPos); 
		GUI.Box (new Rect (indPos.x, indPos.y, scaleRes * iconSize, scaleRes * iconSize), icon,gooey);
		GUIUtility.RotateAroundPivot(0, indPos); 
	}
}

void OnBecameInvisible() {
	visible = false;
}

void OnBecameVisible() {
	visible = true;
}
}