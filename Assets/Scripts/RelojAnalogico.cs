using System;
using UnityEngine;

public class RelojAnalogico : MonoBehaviour
{
    public Transform horero;
    public Transform minutero;
    public Transform segundero;

    public AudioSource audioSource;

    private int ultimoSegundo = -1;

    void Update()
    {
        DateTime ahora = DateTime.Now;

        Debug.Log("Hora actual: " + ahora.ToString("HH:mm:ss"));

        float segundos = ahora.Second + ahora.Millisecond / 1000f;
        float minutos = ahora.Minute + segundos / 60f;
        float horas = (ahora.Hour % 12) + minutos / 60f;

        float anguloSegundos = segundos * 6f;
        float anguloMinutos = minutos * 6f;
        float anguloHoras = horas * 30f;

        float offset = -90f;

        segundero.localRotation = Quaternion.Euler(0, anguloSegundos + offset, 0);
        minutero.localRotation = Quaternion.Euler(0, anguloMinutos + offset, 0);
        horero.localRotation = Quaternion.Euler(0, anguloHoras + offset, 0);

        if (ahora.Second != ultimoSegundo)
        {
            ultimoSegundo = ahora.Second;

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }
}