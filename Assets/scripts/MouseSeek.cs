using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeek : MonoBehaviour
{
    private Vector3 postion; //distance
    public float maxV;
    public Vector3 steering;
    public Vector3 finalV;

    public Vector3 vDisired;
    public Vector3 Velocity;

    void Update()
    {
        /*
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
        */

        postion = transform.position;

        postion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - postion;

        vDisired = postion.normalized * maxV * Time.deltaTime;

        steering = vDisired + Camera.main.ScreenToWorldPoint(Input.mousePosition);

        finalV = steering * maxV * Time.deltaTime;

        transform.position += finalV;
    }
}
