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


    private void FixedUpdate()
    {
       float movimientoHorizontal = Input.GetAxis("Horizontal");
       float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }


        Vector3 movimiento = new Vector3(direccion.x * velocidad, rb.linearVelocity.y, direccion.z * velocidad);

       // Debug.Log("movimiento Magnitud: " + movimiento.magnitude);

        rb.linearVelocity = movimiento;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Trigger collectible");
            Destroy(other.gameObject);
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collision collectible");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }
   
}
