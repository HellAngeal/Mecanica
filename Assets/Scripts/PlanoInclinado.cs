using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoInclinado : MonoBehaviour
{
    //public GameObject[] RAMPS;
    private float g = -9.81f, y1, yf;
    float distance;
    float time;

    GameObject plank;

    bool useSen;
    public bool llegado = false;
    Vector3 startPos;
    public void Start()
    {
        y1 = transform.position.y;

        CastearRayDown();
        time = Mathf.Abs(CalculatTime(distance));
        StartCoroutine(MoveToPlank(transform.position, new Vector3(transform.position.x, transform.position.y - distance, transform.position.z), time));
        startPos = plank.GetComponent<WayPoints>().WayPointB.transform.position;
       
    }

    void CastearRayDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            distance = Mathf.Abs(hit.distance - transform.localScale.x / 2);
            Debug.Log("distancia: " + distance );
            plank = hit.collider.gameObject;
        }
    }

    IEnumerator MoveToPlank(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;
        while (lerpValue < time)
        {
            this.transform.position = Vector3.Lerp(a, b, lerpValue);

            lerpValue += Time.deltaTime;
            yield return null;
        }
        this.transform.position = b;

        
        plank.GetComponent<WayPoints>().WayPointA.transform.position = b;
        CalculateDistanceOfPlank();


    }

    float CalculatTime(float d)
    {

        return distance / g;
    }

    float SacarPX(float hipotenusa, float angle)
    {
        float distance;
        if (plank.GetComponent<WayPoints>().sen)
        {
            //true
            float angle2 = angle;
            angle2 = angle * Mathf.PI / 180;
            float angulorad = Mathf.Sin(angle2);
           
            Debug.Log("angulo rad: " + angulorad);
            //Debug.Log(angle2);
            distance = Mathf.Sin(angle) * hipotenusa;
            useSen = false;
        }
        else
        {
            //false
            distance = Mathf.Cos(angle) * hipotenusa;
            useSen = true;
        }

        return distance;
    }

    float SacarPY(float hipotenusa, float angle)
    {
        float distance;
        if (useSen)
        {
            //true
            distance = Mathf.Sin(angle) * hipotenusa;
        }
        else
        {
            //false
            distance = Mathf.Cos(angle) * hipotenusa;
        }

        return Mathf.Abs(distance);
    }

    float getAceleration(float fuerza, float maza)
    {
        return fuerza / maza;
    }


    void CalculateDistanceOfPlank()
    {

        float hipotenusa = plank.transform.localScale.x; //horizontal diustance
        float angle = plank.transform.localEulerAngles.z;
        float height = Mathf.Sin(angle) * hipotenusa; // distnacia de altura
        //float horizontal_height = Mathf.Cos(angle) * hipotenusa;
        float masa = 1;
        // m * g
        //9.81 p
        float peso = masa * g;

        Debug.Log(hipotenusa);



        float fx = SacarPX(hipotenusa, angle);
        float fy = SacarPY(hipotenusa, angle);
        float aceleration = getAceleration(fx, 1);
        //0.98 a
        //24.75
        //vf = 4.97

        StartCoroutine(MoveFromAtoB(plank.GetComponent<WayPoints>().WayPointA.transform.position, plank.GetComponent<WayPoints>().WayPointB.transform.position, 5.064f, hipotenusa));


        //calcular nuevo vector y usar de nuevo el lerp /tiempo
    }
    float TimeParaRecorrer(float distancia, float aceleracion)
    {
        float tiempo = Mathf.Sqrt(25.64f);


        return tiempo;
    }
    IEnumerator MoveFromAtoB(Vector3 a, Vector3 b, float t, float hipotenusa)
    {
        float lerpValue = 0.0f;
        float Perc;
        while (lerpValue < t)
        {
            Perc = lerpValue / t;
            this.transform.position = Vector3.Lerp(a, b, Perc);

            lerpValue += Time.deltaTime;
            yield return null;
        }
        llegado = true;
        yield return null;
    }
    public Vector3 targetPos;
    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;
   
    
    void Update()
    {
        // Calcula la siguiente posicion, con el angulo puesto

        if(llegado ==true)
        {
        MovementParabolic();
        //CastearRayDown();

        }
    }

    public void MovementParabolic()
    {
        // Calcula la siguiente posicion, con el angulo puesto
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0; // sacamos la distancia
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime); // El movimiento MRU
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist); //la formula para obtener el maximo de  trabajo de arco a cualquier altura de arco que haya especificado.
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Gira para apuntar la siguiente posición y luego muévete allí
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;
        // Haz algo cuando se llega a la posicion
        if (nextPos == targetPos) Arrived();
    }
    void Arrived()
    {
        Destroy(gameObject);
    }
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

}
