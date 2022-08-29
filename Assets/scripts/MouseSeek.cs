using UnityEngine;

public class MouseSeek : MonoBehaviour
{
    private Vector3 postion; //distance
    public float maxV;
    private Vector3 vDisired;
    private Vector3 steering;
    private Vector3 finalV; 

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);

        postion = transform.position;

        postion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - postion;

        vDisired = postion.normalized * maxV;

        steering = vDisired * Time.deltaTime;

        finalV = steering;

        transform.position += new Vector3(finalV.x, finalV.y, 0);
    }
}
