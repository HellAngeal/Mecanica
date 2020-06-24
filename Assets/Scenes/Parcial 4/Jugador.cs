using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{
    #region variables Aceleracion = F / M;
    public float fuerza = 0f;
    [SerializeField] float masa = 1f;
    #endregion

    const float gravedad = 9.81f;


    #region Friccion = u * N;
    public float coeficienteFriccion;
    public float Normal;
    public float fuerzaFriccion;
    #endregion
    // Start is called before the first frame update


    Rigidbody2D rb;
    [SerializeField]
    float fuerzaSalto;
    bool puedeSaltar;
    // Update is called once per frame

    public Sprite[] spritesHearth;
    public Image Heart;
    public int HP;

    public Image[] balitasImagenes;
    [SerializeField] GameObject balitas;
    public int contadorMunicion = 3;
    


    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Aceleracion(fuerza, masa, fuerzaFriccion);
       

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar == true)
        {
            Saltar();
            puedeSaltar = false;
        }

        if(Input.GetKeyDown(KeyCode.P)&&contadorMunicion!=0)
        {
            Disparar();
        }

     
    }

    //Deteccion de materiales para sacar los coeficiente
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            puedeSaltar = true;
        }
        if (collision.gameObject.CompareTag("Hielo"))
        {
            coeficienteFriccion = 0.09f;
        }
        else if (collision.gameObject.CompareTag("Pasto"))
        {
            coeficienteFriccion = 0.35f;
        }else if(collision.gameObject.CompareTag("Esferas"))
        {
            collision.gameObject.SetActive(false);
            HP--;

            if (HP < 0)
            {
                SceneManager.LoadScene(4);
             }

            switch (HP)
            {
                case 0:
                    Heart.sprite = spritesHearth[3];
                    break;
                case 1:
                    Heart.sprite = spritesHearth[2];
                    break;
                case 2:
                    Heart.sprite = spritesHearth[1];
                    break;
                case 3:
                    Heart.sprite = spritesHearth[0];
                    break;
            }
        }
        FuerzaFriccion(coeficienteFriccion, masa);

    }

    //FORMULA PARA SACAR FUERZA DE FRICCION
    void FuerzaFriccion(float coeficienteFriccion, float masa)
    {
        Normal = masa * gravedad;
        fuerzaFriccion = coeficienteFriccion * Normal;

    }

    //ACELERACION Y RESTARLE LA FUERZA DE FRICCION A LA FUERZA
    void Aceleracion(float fuerza, float masa, float fuerzaFriccion)
    {
        fuerza -= fuerzaFriccion;
        float aceleracionF = fuerza / masa;

  
        transform.position += Vector3.right * aceleracionF * Time.deltaTime;
    }


    void Disparar()
    {
        Vector3 balita= new Vector3(0.4f, 0,0);
        Vector3 offset = transform.position + balita;
        Quaternion facingPlayerX = Quaternion.LookRotation(Vector3.forward);
        Instantiate(balitas, offset, facingPlayerX);
        contadorMunicion -= 1;
    }
    void Saltar()
    {

        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);

    }
}
