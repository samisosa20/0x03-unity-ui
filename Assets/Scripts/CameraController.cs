using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet;

    // Update is called once per frame
    public void FixedUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
