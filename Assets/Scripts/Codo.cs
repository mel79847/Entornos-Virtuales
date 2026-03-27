using UnityEngine;

public class Codo : MonoBehaviour
{

    public float velocidad = 50.0f;
    float anguloMinimo = 60f;
    float anguloMaximo = 100f;
    private float anguloAcumulado = 0f;

    void Start()
    {
        //Debug.Log("Codo iniciado");
    }

    
    void Update()
    {
        float movimiento = Mathf.PingPong(Time.time * velocidad, 1.0f);
        float anguloActual = Mathf.Lerp(anguloMinimo, anguloMaximo, movimiento);

        transform.localRotation = Quaternion.Euler(anguloActual, 0f, 0f);


    }
}
