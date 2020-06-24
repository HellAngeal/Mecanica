using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Aceleracion(fuerza, masa, fuerzaFriccion);
        Debug.Log("Coeficiente Friccion: " + coeficienteFriccion + "FuerzaFriccion: " + fuerzaFriccion);

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar == true)
        {
            Saltar();
            puedeSaltar = false;
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

        Debug.Log("aceleracion: " + aceleracionF);
        transform.position += Vector3.right * aceleracionF * Time.deltaTime;
    }

    void Saltar()
    {

        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);

    }
}
