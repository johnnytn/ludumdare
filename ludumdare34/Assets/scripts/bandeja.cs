using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bandeja : MonoBehaviour {

	private BoxCollider2D bandej;
	private GameObject bandejaObj;

	// Use this for initialization
	void Start () {
		bandejaObj = GameObject.FindGameObjectWithTag ("bandeja");
		bandej = bandejaObj.GetComponent<BoxCollider2D>() as BoxCollider2D;
	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D colisor){

		Debug.Log (colisor.gameObject.tag);

		if (colisor.gameObject.tag == "triggerBau") {	 
			Debug.Log ("colidiu na caçamba");
			bandej.enabled = false;

			List<Transform> unparent = new List<Transform>(transform.childCount);

			foreach (Transform child in bandejaObj.transform)
				if (child.tag == "pizza") {
					unparent.Add(child);
					child.GetComponent<pizza> ().naBandeja = false;
				}
			foreach (Transform child in unparent)
			{
				child.parent = null;
			}
		}

	}

	void OnTriggerExit2D(Collider2D colisor){

		Debug.Log ("SAIUUUUUUUUUU" + colisor.gameObject.tag);

		if (colisor.gameObject.tag == "triggerBau") {	 
			Debug.Log ("saiu da caçandaco");
			bandej.enabled = true;
		}

	}



}

