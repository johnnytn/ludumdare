using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Vidas : MonoBehaviour {


	public Sprite[] vidaAtual;
	private int vidas;
	private int contador;


	// Use this for initialization
	void Start () {

		GetComponent<Image>().sprite = vidaAtual[0];
		vidas = vidaAtual.Length;
	}

	// Update is called once per frame
	void Update () {

	}


	public bool ExcluirVida(){

		if (vidas < 0) {
			return false;		
		}

		if (contador < (vidas - 1)) {

			Debug.Log (contador);
			contador += 1;
			GetComponent<Image>().sprite = vidaAtual [contador];
			return true;

		} else {

			return false;

		}


	}
}
