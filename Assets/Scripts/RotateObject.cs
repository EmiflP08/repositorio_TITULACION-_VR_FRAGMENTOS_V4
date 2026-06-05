using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class RotateObject : MonoBehaviour
{
    [Header("Rotation Speed (degrees per second)")]
    public float speedX = 0f;
    public float speedY = 90f;
    public float speedZ = 0f;
    

    [Header("Settings")]
    public Space rotationSpace = Space.Self;

    void Update()
    {
        transform.Rotate(speedX * Time.deltaTime,
                         speedY * Time.deltaTime,
                         speedZ * Time.deltaTime,
                         rotationSpace);
    }
}