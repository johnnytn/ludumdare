using UnityEngine;
using System.Collections;

public class PizzaBehavior : MonoBehaviour {

	private Transform bandeja;
	private bool naBandeja;

	private Vector3 velocity = Vector3.zero;
	public float dampTime = 0.15f;

	// Use this for initialization
	void Start () {
		bandeja = GameObject.FindGameObjectWithTag("bandeja").transform;
	}

	
	// Update is called once per frame
	void Update () {

		if (naBandeja) {
			//this.transform.position = new Vector2( bandeja.position.x , transform.position.y);

		}
	
	}

	public void OnCollisionEnter2D (Collision2D hit) 
	{ 
		Debug.Log ("COLIDIU " + hit.gameObject.name);
		if (hit.gameObject.tag == "bandeja" || hit.gameObject.tag == "pizza") {
			naBandeja = true;
			transform.parent = bandeja; 
		} else {
			Destroy(gameObject);
		}
	}
}