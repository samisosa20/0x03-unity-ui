using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{
    public float degreesPerSecond = 45f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime, 0, 0);
    }
}
