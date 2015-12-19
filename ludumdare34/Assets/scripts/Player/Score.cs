using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public static int ponto;
    public static Score instance;
    public UnityEngine.UI.Text txtPonto;

    void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start() {
        txtPonto.text = "Points: " + ponto;
    }

    // Update is called once per frame
    void Update() {

    }

    public void SomarPonto(int _ponto) {
        ponto += _ponto;
        txtPonto.text = "Points: " + ponto;
    }


    public void TirarPonto(int _ponto) {
        ponto -= _ponto;
        txtPonto.text = "Points: " + ponto;
    }

    // Pega a maior pontuação do jogador entre todas as vezes que ele jogou
    public void Recorde() {
        if (ponto > PlayerPrefs.GetInt("recorde")) {
            PlayerPrefs.SetInt("recorde", ponto);
        }
    }

    // Pega a pontuação total do jogador
    public void Pontuacao() {
        PlayerPrefs.SetInt("pontuacao", ponto);
    }

    public static void Inicializar() {
        ponto = 0;
    }

}