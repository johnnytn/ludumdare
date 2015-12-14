using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class pizza : MonoBehaviour {

	private Transform bandeja;
	public bool naBandeja;

	public float dampTime = 0.15f;
	private Vidas vida;
	new private AudioSource audio;
	public AudioSource fail;

	private GameObject go;

	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("vidas");
		bandeja = GameObject.FindGameObjectWithTag("bandeja").transform;
		audio = gameObject.GetComponent<AudioSource>();
		fail = GameObject.FindGameObjectWithTag("somFail").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	void OnCollisionEnter2D(Collision2D colisor){

		if (!naBandeja) {
			//Debug.Log ("COLIDIU " + colisor.gameObject.name);
			if (colisor.gameObject.tag == "bandeja") {
				naBandeja = true;
				transform.parent = bandeja;
				audio.Play ();
			} else if (colisor.gameObject.tag == "pizza") {
				if (colisor.transform.GetComponent<pizza> ().naBandeja == true) {
					naBandeja = true;
					transform.parent = bandeja;
					audio.Play ();
				}
			} else {
				Destroy (gameObject);
			}
		}
			
		vida = go.GetComponent<Vidas> ();

		if (colisor.gameObject.name == "chao") {
			if (vida.ExcluirVida ()) {
				
				fail.Play ();
			} else {
				SceneManager.LoadScene ("GameOver");
			}
		}
	}
}
