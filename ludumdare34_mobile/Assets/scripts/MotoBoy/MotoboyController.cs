using UnityEngine;
using System.Collections;

public class MotoboyController : MonoBehaviour {

	public enum Direction {Left, Right}

	public Direction direction = Direction.Left;

	public GameObject spawner;
	public float targetPositionX;
	public float speed;
	public float acelleration;

	public AudioSource audioSource;
	public AudioClip startSound, breakSound;

	public bool isGoing;
	public bool isDelivering = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isGoing) {
			float xBefore = transform.position.x;
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			speed += (acelleration * Time.deltaTime);

			if ((transform.position.x > xBefore && xBefore <= targetPositionX && targetPositionX <= transform.position.x) ||
			    transform.position.x < xBefore && transform.position.x <= targetPositionX && targetPositionX <= xBefore) {
				transform.position = new Vector3 (targetPositionX, transform.position.y, transform.position.z);
				isGoing = false;

				if (breakSound && audioSource) {
					audioSource.clip = breakSound;
					audioSource.Play ();
				}

				if (isDelivering) {
					spawner.GetComponent<MotoboySpawner> ().Spawn ();
					Destroy (gameObject);
				}
			}
		}
	}


	public void Go() {
		if (direction == Direction.Left) {
			speed = 0;
			acelleration = -20;
			targetPositionX = -30;
		} else if (direction == Direction.Right) {
			speed = 0;
			acelleration = 20;
			targetPositionX = 30;
		}

		if (startSound && audioSource) {
			audioSource.clip = startSound;
			audioSource.Play ();
		}

		isDelivering = true;
		isGoing = true;
	}
}
