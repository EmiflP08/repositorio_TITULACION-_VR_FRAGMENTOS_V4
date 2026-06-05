using UnityEngine;

// Script universal para mostrar texto en pantalla y ocultarlo cuando el usuario completa una acción.
// Úsalo en el objeto Trigger de cada sala.
// Para ocultar el texto: llama OcultarTexto() desde el evento del objeto interactuable (botón, taza, libro, papeles, etc.)

public class MostrarTextoAccion : MonoBehaviour
{
    [Header("Canvas con el texto a mostrar")]
    public GameObject canvasTexto;

    [Header("(Opcional) Segundos antes de ocultar automáticamente — 0 = no ocultar solo")]
    public float segundosAutoOcultar = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasTexto.SetActive(true);
            Debug.Log("[MostrarTexto] Texto activado: " + canvasTexto.name);

            if (segundosAutoOcultar > 0f)
                Invoke(nameof(OcultarTexto), segundosAutoOcultar);
        }
    }

    // Llama este método desde el evento del objeto interactuable para ocultar el texto
    public void OcultarTexto()
    {
        if (canvasTexto != null)
        {
            canvasTexto.SetActive(false);
            Debug.Log("[MostrarTexto] Texto ocultado: " + canvasTexto.name);
        }
    }
}
