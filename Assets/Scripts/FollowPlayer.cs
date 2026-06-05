using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    public Vector3 offset;


    void Update()
    {
            this.transform.position = player.position + offset;
    }


}