﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pizza : MonoBehaviour {

    private Transform bandejaGO;
    public bool naBandeja;

    public float dampTime = 0.15f;
    private Vidas vida;
    new private AudioSource audio;
    public AudioSource fail;

    private GameObject vidasGO;

    // Use this for initialization
    void Start() {
        vidasGO = GameObject.FindGameObjectWithTag("vidas");
        bandejaGO = GameObject.FindGameObjectWithTag("bandeja").transform;
        audio = gameObject.GetComponent<AudioSource>();
        fail = GameObject.FindGameObjectWithTag("somFail").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // TODO : testar para ver se resolveu o bug das pizzas que ficam grudadas no fundo
        if (this.transform.position.y < bandejaGO.transform.position.y) {
            alterarEstadoPiza(false);
        }
    }

    void OnCollisionEnter2D(Collision2D colisor) {

        if (!naBandeja) {
            if (colisor.gameObject.tag == "bandeja" || ((colisor.gameObject.tag == "pizza") && (colisor.transform.GetComponent<Pizza>().naBandeja == true))) {
                this.alterarEstadoPiza(true);
            } else {
                Debug.Log("COLIDIU " + colisor.gameObject.name);
                Destroy(gameObject);
            }
        }

        if (colisor.gameObject.name == "chao") {
            vida = vidasGO.GetComponent<Vidas>();
            if (vida.ExcluirVida()) {
                fail.Play();
            } else {
                Application.LoadLevel("GameOver");
            }
        }
    }

    // Altera o estado da pizza e aciona o audio caso colida com a badeja
    private void alterarEstadoPiza(bool naBandeja) {
        this.naBandeja = naBandeja;
        transform.parent = naBandeja ? bandejaGO : null;
        if (naBandeja) {
            audio.Play();
        }
    }
}
