using UnityEngine;

public class MostrarTexto : MonoBehaviour
{
    public GameObject canvasTexto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Paso!");
            canvasTexto.SetActive(true);
        }
    }
}