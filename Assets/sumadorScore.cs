using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sumadorScore : MonoBehaviour
{
    // Start is called before the first frame update


    public int score = 0;
    
    public Text scoreText;

    void Start()
    {
        scoreText.GetComponent<Text>();
        scoreText.text = "SCORE: " + score;

    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Esferas"))
        {
            scoreText.text = "SCORE: " + score;
            score += 1;
            scoreText.text = "SCORE: " + score;
        }
    }
}
