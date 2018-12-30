using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float speed = 0.5f;
	public Vector3 castlePosition;
	private Vector3 targetPosition;
	public bool enteredCastle;
	

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit))
			{
			if (hit.transform.GetComponent<DoorButton>() != null) {
				hit.transform.GetComponent<DoorButton>().OnLook ();
				MoveToCastle ();
			}
				
			if (GvrViewer.Instance.Triggered || Input.GetKeyDown ("space")) {
				RaycastHit enemyHit;
				if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out enemyHit)){
					if (hit.transform.GetComponent<Enemy>() != null) {
						Destroy(hit.transform.gameObject);
						



					}



				}
			}
			
			}
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);



			   	  }
	public void MoveToCastle(){
	
		targetPosition = castlePosition;
		enteredCastle = true;
	}
}