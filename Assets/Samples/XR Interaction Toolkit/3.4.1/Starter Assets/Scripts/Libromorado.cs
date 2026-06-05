using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LibroMorado : MonoBehaviour
{
    [Header("Posiciones donde reaparece el libro")]
    public Transform[] posicionesReaparicion;

    [Header("Botón Guardar Libro")]
    public GameObject canvasGuardarLibro;

    [Header("Texto en pantalla")]
    public MostrarTextoAccion triggerEstudio;

    private bool yaSeMovio = false;
    private XRSimpleInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(AlTocarLibro);

        if (canvasGuardarLibro != null)
            canvasGuardarLibro.SetActive(false);
    }

    void AlTocarLibro(SelectEnterEventArgs args)
    {
        if (!yaSeMovio)
        {
            // Primera vez: se mueve a PosLibro2
            yaSeMovio = true;
            transform.position = posicionesReaparicion[1].position;
            Debug.Log("[Libro] Reapareció en PosLibro2");

            // Desuscribir para que el próximo toque use AlTocarLibroDespues
            interactable.selectEntered.RemoveListener(AlTocarLibro);
            interactable.selectEntered.AddListener(AlTocarLibroDespues);
        }
    }

    void AlTocarLibroDespues(SelectEnterEventArgs args)
    {
        // Segunda vez: muestra botón Guardar libro
        if (canvasGuardarLibro != null)
            canvasGuardarLibro.SetActive(true);
        Debug.Log("[Libro] Mostrando botón Guardar libro");

        // Desuscribir para que no se repita
        interactable.selectEntered.RemoveListener(AlTocarLibroDespues);
    }

    public void GuardarLibro()
    {
        Debug.Log("[Libro] ¡Libro guardado!");
        if (canvasGuardarLibro != null)
            canvasGuardarLibro.SetActive(false);
        if (triggerEstudio != null)
            triggerEstudio.OcultarTexto();
        gameObject.SetActive(false);
    }
}
