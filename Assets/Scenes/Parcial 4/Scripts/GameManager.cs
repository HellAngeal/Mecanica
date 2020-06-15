using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleManager manager;
    public ParticleWithCharge center;
    public MoveableParticle one, two;

    float multiplier = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(-6.77f, 0.008f);
            center.charge +=  multiplier;

            int randomNum = Random.Range(0, 10);
            one.masa += multiplier;
            two.masa += multiplier;
            if (randomNum <= 5)
            {
                one.charge= one.charge * -1;
                two.charge = two.charge * 1;
            }
            else
            {
                one.charge = one.charge * 1;
                two.charge = two.charge * -1;
            }
         
            if(!(manager.cycleInterval <= 0.1f))
            {
                manager.cycleInterval -= 0.1f;
            }
          
            one.gameObject.transform.localPosition = new Vector2(Random.Range(-1, -4), Random.Range(0, 1));
            two.gameObject.transform.localPosition = new Vector2(Random.Range(1, 4), Random.Range(0, 1));
            multiplier+= 0.1f;

        }
    }
}
