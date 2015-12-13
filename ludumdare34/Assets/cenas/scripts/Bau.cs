using UnityEngine;
using System.Collections;

public class Bau : MonoBehaviour {

	private Score score;
	private int pontos = 10;
	private AudioSource audio;

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
			score.SomarPonto (pontos);
			audio.Play ();
		} else {
			Destroy(gameObject);
		}



	}
}
