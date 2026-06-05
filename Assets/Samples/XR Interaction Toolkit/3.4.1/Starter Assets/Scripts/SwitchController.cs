using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchController : MonoBehaviour
{
    [Header("Lamp")]
    public Light luzLampara;

    [Header("Object to Follow Player")]
    public GameObject Papelitos;

    public void ApagarLampara()
    {
        luzLampara.enabled = false;

        if (Papelitos != null)
            Papelitos.SetActive(true);
    }
}