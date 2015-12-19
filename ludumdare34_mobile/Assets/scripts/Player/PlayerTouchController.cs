using UnityEngine;
using System.Collections;

public class PlayerTouchController : MonoBehaviour {

	public float minBounds, maxBounds;
	public float moveDistance;
	public float delayBetweenMovements;
	public float rotationOffset = 0;

	public AudioSource audioSource;
	public AudioClip scoreClip;

	public Sprite[] players;
	public SpriteRenderer pls;

	private float lastMovementTime;
	private float input;
	private float orientation;

	private GUITexture bto;
	public Transform player;


	// Use this for initialization
	void Start () {
		lastMovementTime = Time.timeSinceLevelLoad;
		pls = GameObject.FindGameObjectWithTag("hero").GetComponent<SpriteRenderer>();
		bto = gameObject.GetComponent<GUITexture> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();



	}


	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - lastMovementTime >= delayBetweenMovements) {
			

			foreach (UnityEngine.Touch touch in Input.touches) {

				if (bto.HitTest (touch.position)) {

					if (touch.phase != TouchPhase.Ended) {
						if (bto.name == "direito") {

							orientation = Mathf.Abs (player.transform.localScale.x);
							if (player.transform.localScale.x != orientation) { //Looking to other direction
								player.transform.localScale = new Vector3 (-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
								player.transform.Translate (Vector3.left * rotationOffset);
							} else if (player.transform.position.x + moveDistance <= maxBounds) //Doesnt allow player reach area outside bounds
								player.transform.Translate (Vector3.right * moveDistance);

							lastMovementTime = Time.timeSinceLevelLoad;

						}


						if (bto.name == "esquerdo") {
							orientation = Mathf.Abs (player.transform.localScale.x);
							if (player.transform.localScale.x != -orientation) {//Looking to other direction 
								player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
								player.transform.Translate (Vector3.right * rotationOffset);
							}
							else if (player.transform.position.x - moveDistance >= minBounds) //Doesnt allow player reach area outside bounds
								player.transform.Translate(Vector3.left * moveDistance);

							lastMovementTime = Time.timeSinceLevelLoad;
						}
					}

				}


			}
		}

		if (player.transform.position.x == 4) {
			pls.sprite = players [2];
		}else if(player.transform.position.x == -4){
			pls.sprite = players [2];
		}

		if (player.transform.position.x == 2) {
			pls.sprite = players [1];
		}else if(player.transform.position.x == -2){
			pls.sprite = players [1];
		}

		
		if (player.transform.position.x == 0) {
			pls.sprite = players [0];
		}else if(player.transform.position.x == -0){
			pls.sprite = players [0];
		}


	}



}
