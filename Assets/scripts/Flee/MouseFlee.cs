using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlee : MonoBehaviour
{
    private float speed;
    private Vector3 currentV;
    private float pProduct;

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
        pProduct = Mathf.Sqrt(Mathf.Pow(camerapos.x - transform.position.x, 2) + Mathf.Pow(camerapos.y - transform.position.y, 2));
        Vector3 position = transform.position - camerapos;
        Vector3 vDisired = position.normalized * speed;
        Vector3 steering = vDisired - currentV;
        currentV += steering;
        transform.position += currentV * Time.deltaTime;

        DistanceAplication();
    }

    private void DistanceAplication()
    {
        if(pProduct > 20)
        {
            speed = 0;
        }
        if (pProduct < 20 && pProduct > 10)
        {
            speed = 5;
        }

        if(pProduct < 10)
        {
            speed = 10;
        }
    }
}
