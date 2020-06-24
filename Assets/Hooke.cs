using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hooke : MonoBehaviour
{
    [SerializeField]
    float fuerzaElastica;
    [SerializeField]
    float kConstante;
    [SerializeField]
    float X;
    [SerializeField]
    Jugador Drewsin;

    // Update is called once per frame

    float power=1.5f;
    public float maxPower = 10f;
    public Slider powerSlider;
    public GameObject plataformita;
   
    bool Jugador;
    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = 0.0f;
        powerSlider.maxValue = maxPower;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Jugador)
        {
            powerSlider.gameObject.SetActive(true);
            Debug.Log("putoelKOKO");
        }
        else if(Jugador!=true)
        {
            powerSlider.gameObject.SetActive(false);
        }
        powerSlider.value = power;
      
        
        if (Input.GetKey(KeyCode.S))
        {
            if (power <= maxPower)
            {
                power += 5f * Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            
            X = Mathf.Abs(power);
          
            
            LeyHooke(kConstante, X);
        }
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Jugador = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Jugador = false;
        power = 0f;

        gameObject.SetActive(false);
        powerSlider.gameObject.SetActive(false);
        plataformita.SetActive(false);
    }



    void LeyHooke(float k, float x)
    {

        fuerzaElastica = k * x;
        Drewsin.fuerza = fuerzaElastica;
    }

}

