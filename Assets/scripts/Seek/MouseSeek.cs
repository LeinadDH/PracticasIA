using Unity.VisualScripting;
using UnityEngine;

public class MouseSeek : MonoBehaviour
{
    private int speed;
    private Vector3 currentV;
    private float pProduct;
    public float mass;

    private void Start()
    {
        currentV = Vector3.zero;
    }

    void Update()
    {
        Rotation();
        Seek();
    }

    public void Rotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, distance);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Seek()
    {
        Vector3 camerapos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camerapos.z = 0;
        pProduct = Mathf.Sqrt(Mathf.Pow(camerapos.x - transform.position.x, 2) + Mathf.Pow(camerapos.y - transform.position.y, 2));

        Vector3 position = camerapos - transform.position;

        Vector3 vDisired = position.normalized * (speed/mass);
        Vector3 steering = vDisired - currentV;
        currentV += steering;
        transform.position += currentV * Time.deltaTime;

        DistanceAplication();
    }

    private void DistanceAplication()
    {
        if (pProduct > 20)
        {
            speed = 10;
        }
        if (pProduct < 20 && pProduct > 5)
        {
            speed = 5;
        }
        if (pProduct < 5)
        {
            speed = 0;
        }
    }
}
