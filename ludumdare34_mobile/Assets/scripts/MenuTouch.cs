using UnityEngine;
using System.Collections;

public class MenuTouch : MonoBehaviour {

	private GUITexture bto;


	// Use this for initialization
	void Start () {
		bto = gameObject.GetComponent<GUITexture> ();
	}


	void Update() {
		foreach (UnityEngine.Touch touch in Input.touches) {

			if (bto.HitTest (touch.position)) {

				if (touch.phase != TouchPhase.Ended) {
					if (bto.name == "start") {

						Application.LoadLevel (1);

					}


					if (bto.name == "esquerdo") {

					}
				}

			}


		}

	}
}
