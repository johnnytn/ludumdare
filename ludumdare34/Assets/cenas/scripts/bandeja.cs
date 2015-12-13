using UnityEngine;
using System.Collections;

public class bandeja : MonoBehaviour {

	private BoxCollider2D bandej;
	private Transform allTransforms;


	// Use this for initialization
	void Start () {
		bandej = GameObject.FindGameObjectWithTag("bandeja").GetComponent<BoxCollider2D>() as BoxCollider2D;


	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D colisor){
		

		if (colisor.gameObject.tag == "triggerBau") {	 
			retiraChild ();
			bandej.enabled = false;

		}
			
	}

	void OnTriggerExit2D(Collider2D colisor){

		if (colisor.gameObject.tag == "triggerBau") {	 
			bandej.enabled = true;
		}

	}


	void retiraChild(){
		allTransforms = GameObject.FindGameObjectWithTag ("bandeja").gameObject.GetComponentInChildren<Transform>() as Transform;
		allTransforms.DetachChildren ();

	}



}
