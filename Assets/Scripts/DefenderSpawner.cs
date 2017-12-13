using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject DefendersParent;
	private StarDisplay starDisplay;

	void Start() {	
		DefendersParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!DefendersParent){
			DefendersParent = new GameObject("Defenders Parent");
		}
	}

	void OnMouseDown() {
		//print (Input.mousePosition);
		//print (SnapToGrid (CalculateWorldPointOfMouseClick ()) );
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRotation) as GameObject;
		newDef.transform.parent = DefendersParent.transform;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX =  Mathf.RoundToInt (rawWorldPos.x);
		float newY =  Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);

	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
