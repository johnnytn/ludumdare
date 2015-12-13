using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject pan;
	public float bounds;
	public float moveDist;
	public float delayBetweenMovements;


	private float lastMovementTime = .01f;
	private float input;
	private float orientation;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - lastMovementTime >= delayBetweenMovements) {
			input = Input.GetAxisRaw ("Horizontal");

			if (input > 0.1) {
				orientation = Mathf.Abs (transform.localScale.x);
				if (transform.localScale.x != orientation) { //Looking to other direction
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (transform.position.x + moveDist <= bounds) //Doesnt allow player reach area outside bounds
					transform.Translate(Vector3.right * moveDist); 

				lastMovementTime = Time.timeSinceLevelLoad;
			} else if (input < -0.1) {
				orientation = Mathf.Abs (transform.localScale.x);
				if (transform.localScale.x != -orientation) {//Looking to other direction 
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (transform.position.x - moveDist >= -bounds) //Doesnt allow player reach area outside bounds
					transform.Translate(Vector3.left * moveDist);

				lastMovementTime = Time.timeSinceLevelLoad;
			}
		}
	}
}