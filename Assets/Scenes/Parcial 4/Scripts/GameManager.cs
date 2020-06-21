using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleManager [] manager;
    public ParticleWithCharge[] center;
    public MoveableParticle[] one;
    public MoveableParticle[] two;
    float multiplier = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int x = 0; x < manager.Length; x++)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.position = new Vector2(-6.77f, 0.008f);
                center[x].charge += multiplier;

                int randomNum = Random.Range(0, 10);
                one[x].masa += multiplier;
                two[x].masa += multiplier;
                if (randomNum <= 5)
                {
                    one[x].charge = one[x].charge * -1;
                    two[x].charge = two[x].charge * 1;
                }
                else
                {
                    one[x].charge = one[x].charge * 1;
                    two[x].charge = two[x].charge * -1;
                }

                if (!(manager[x].cycleInterval <= 0.1f))
                {
                    manager[x].cycleInterval -= 0.1f;
                }

                one[x].gameObject.transform.localPosition = new Vector2(Random.Range(-1, -2), Random.Range(0, 1));
                two[x].gameObject.transform.localPosition = new Vector2(Random.Range(1, 2), Random.Range(0, 1));
                multiplier += 0.1f;

            }
        }
        
    }
}
