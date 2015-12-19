using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float minBounds, maxBounds;
    public float moveDistance;
    public float delayBetweenMovements;
    public float rotationOffset = 0;

    public AudioSource audioSource;
    public AudioClip scoreClip;

    public Sprite[] players;
    public SpriteRenderer pls;

    private float lastMovementTime;
    private float input;
    private float orientation;

    // Use this for initialization
    void Start() {
        lastMovementTime = Time.timeSinceLevelLoad;
        pls = GameObject.FindGameObjectWithTag("hero").GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update() {
        if (Time.timeSinceLevelLoad - lastMovementTime >= delayBetweenMovements) {
            input = Input.GetAxisRaw("Horizontal");

            if (input > 0.1) {
                orientation = Mathf.Abs(transform.localScale.x);
                if (transform.localScale.x != orientation) { //Looking to other direction
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    transform.Translate(Vector3.left * rotationOffset);
                } else if (transform.position.x + moveDistance <= maxBounds) //Doesnt allow player reach area outside bounds
                    transform.Translate(Vector3.right * moveDistance);

                lastMovementTime = Time.timeSinceLevelLoad;
            } else if (input < -0.1) {
                orientation = Mathf.Abs(transform.localScale.x);
                if (transform.localScale.x != -orientation) {//Looking to other direction 
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    transform.Translate(Vector3.right * rotationOffset);
                } else if (transform.position.x - moveDistance >= minBounds) //Doesnt allow player reach area outside bounds
                    transform.Translate(Vector3.left * moveDistance);

                lastMovementTime = Time.timeSinceLevelLoad;
            }
        }
        //StartCoroutine(trocarAleatorioSprite());
        trocarSprite();
    }


    /// teste de random sprite 
    IEnumerator trocarAleatorioSprite() {
        Debug.Log("Before Waiting 2 seconds");
        int atualSprite = 0;
        int proximaSprite = 0;
        if (input != 0) {
            proximaSprite = Random.Range(0, 2);
            if (proximaSprite == atualSprite) {
                proximaSprite = atualSprite == 2 ? atualSprite-- : atualSprite++;
            } 

            pls.sprite = players[proximaSprite];
            atualSprite = proximaSprite;
        }

        yield return new WaitForSeconds(2f);
        Debug.Log("After Waiting 2 Seconds");
    }


    private void trocarSprite() {
        if (transform.position.x == 4) {
            pls.sprite = players[2];
        } else if (transform.position.x == -4) {
            pls.sprite = players[2];
        }

        if (transform.position.x == 2) {
            pls.sprite = players[1];
        } else if (transform.position.x == -2) {
            pls.sprite = players[1];
        }


        if (transform.position.x == 0) {
            pls.sprite = players[0];
        } else if (transform.position.x == -0) {
            pls.sprite = players[0];
        }
    }

}
