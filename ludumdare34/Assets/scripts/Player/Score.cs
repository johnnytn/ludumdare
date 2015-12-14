using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int ponto;
	public static Score instance;
	public UnityEngine.UI.Text txtPonto;


	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		txtPonto.text = "Pontos: " + ponto;
	}

	// Update is called once per frame
	void Update () {

	}

	public void SomarPonto(int _ponto){

		ponto += _ponto;
		txtPonto.text = "Pontos: " + ponto;

	}


	public void TirarPonto(int _ponto){

		ponto -= _ponto;
		txtPonto.text = "Pontos: " + ponto;

	}

	public void Recorde(){

		if(ponto > PlayerPrefs.GetInt("recorde")){
			PlayerPrefs.SetInt("recorde",ponto);
		}

	}


	public static void Inicializar(){
		ponto = 0;
	}


}