using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Vidas : MonoBehaviour {


    public Sprite[] vidaAtual;
    private int vidas;
    private int contador;


    // Use this for initialization
    void Start() {

        GetComponent<Image>().sprite = vidaAtual[0];
        vidas = vidaAtual.Length;
    }

    // Update is called once per frame
    void Update() {

    }

    // Remove vidas do jogador
    public bool ExcluirVida() {

        if (vidas < 0) {
            return false;
        }

        if (contador < (vidas - 1)) {
            contador += 1;
            GetComponent<Image>().sprite = vidaAtual[contador];
            return true;
        }
        return false;
    }
}
