using UnityEngine;

public class Esfera : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidad = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

    }

    
    void Update()
    {

        
    }

    private void FixedUpdate()
    {
       float movimientoHorizontal = Input.GetAxis("Horizontal");
       float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal * velocidad, rb.linearVelocity.y, movimientoVertical * velocidad);

       rb.linearVelocity = movimiento;
    }
}
