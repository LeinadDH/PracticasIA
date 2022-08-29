using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlee : MonoBehaviour
{
    public float speed;
    private Vector3 currentV;

    private void Start()
    {
        currentV = Vector3.zero;
    }

    void Update()
    {
        Flee();
    }

    private void Flee()
    {
        Vector3 camerapos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camerapos.z = 0;
        Vector3 position = transform.position - camerapos;
        Vector3 vDisired = position.normalized * speed;
        Vector3 steering = vDisired - currentV;
        currentV += steering;
        transform.position += currentV * Time.deltaTime;
    }
}
