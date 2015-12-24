using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int ponto;
	public static Score instance;
	public Text txtPonto;

	public int scoreBuffer;

	public Text scoreTextFader;
	public float fadeSpeed = 1f;
	Vector3 posFrom;
	Vector3 posTo;
	Color fadeColorFrom;
	Color fadeColorTo;
	float startTime;



	void Awake(){
		
		instance = this;
		posFrom = new Vector3 (150f, 200f, 100f);
		posTo = posFrom + new Vector3 (0, 100f, 0);
		fadeColorFrom = scoreTextFader.color;
		fadeColorTo = new Color (0, 0, 0, 0);
		scoreTextFader.color = fadeColorTo;

	}

	// Use this for initialization
	void Start () {
		txtPonto.text = "0";

	}

	// Update is called once per frame
	void Update () {
		animaScore ();
	}

	public void animaScore(){

		if (scoreTextFader.transform.position != txtPonto.transform.position) {
			scoreTextFader.transform.position = Vector3.Slerp (posFrom, txtPonto.transform.position, (Time.time - startTime) * fadeSpeed);
			scoreTextFader.color = Color.Lerp (fadeColorFrom, fadeColorTo, (Time.time - startTime) * fadeSpeed);

		}

	}

	public void SomarPonto(int _ponto){
		
		ponto += _ponto;
	    txtPonto.text = " " + ponto;

		scoreTextFader.text = "+" + _ponto;
		scoreTextFader.transform.position = posFrom;
		scoreTextFader.color = fadeColorFrom;
		startTime = Time.time;


	}






	public void TirarPonto(int _ponto){

		ponto -= _ponto;
		txtPonto.text = " "+ponto;

	}

	public void Recorde(){

		if(ponto > PlayerPrefs.GetInt("recorde")){
			PlayerPrefs.SetInt("recorde",ponto);
		}

	}

	public void Pontuacao(){
		PlayerPrefs.SetInt ("pontuacao", ponto);
	}


	public static void Inicializar(){
		ponto = 0;
	}


}