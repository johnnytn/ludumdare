using UnityEngine;
using System.Collections;

public class Bau : MonoBehaviour {

	public float multiplicatorTimeLimit = 1;

	private Score score;
	private int pontos = 10;
	new private AudioSource audio;

	private float timeSinceLastCollision;
	private int multiplicationRatio = 1;

	// Use this for initialization
	void Start () {
		score = GameObject.FindGameObjectWithTag("pontos").GetComponent<Score>();
		audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colisor){


		if (colisor.gameObject.tag == "pizza") {
			Debug.Log ("Pizza na moto, partiu!!");
			audio.Play ();

			if (Time.timeSinceLevelLoad - timeSinceLastCollision > multiplicatorTimeLimit)
				multiplicationRatio = 1;
			else
				multiplicationRatio++;

			score.SomarPonto (multiplicationRatio * pontos);
				

			timeSinceLastCollision = Time.timeSinceLevelLoad;
		} else {
			Destroy(gameObject);
		}



	}
}
