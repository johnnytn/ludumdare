using UnityEngine;
using System.Collections;

public class btoController : MonoBehaviour {


	public void botaoPlay(){
		Application.LoadLevel (1);
		scoreAdder.Inicializar ();
	}


	public  void botaoQuit(){
		
		Application.Quit();
		Debug.Log ("Saiu do jogo");

	}


}
