using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disparar : MonoBehaviour
{
    // Start is called before the first frame update

    Jugador drewsin;
    Rigidbody2D balita;
    float fuerzadisparo;
    Renderer balita_Renderer;
    sumadorScore text;
    // Use this for initialization


    private void Start()
    {
        balita = gameObject.GetComponent<Rigidbody2D>();
        drewsin = GameObject.Find("Jugador").GetComponent<Jugador>();
        balita_Renderer = GetComponent<Renderer>();
        text= GameObject.Find("Trigger").GetComponent<sumadorScore>();
        drewsin.balitasImagenes[drewsin.contadorMunicion].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(drewsin.fuerza != 0)
        {
            fuerzadisparo += (drewsin.fuerza * 0.01f);
            balita.AddForce(Vector2.right * fuerzadisparo, ForceMode2D.Impulse);
        }
        if(!balita_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.CompareTag("Esferas"))
        {
            text.score += 1;
            text.scoreText.text = "SCORE: " + text.score;
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }


    }
}
