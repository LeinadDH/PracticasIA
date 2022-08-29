using UnityEngine;

public class MouseSeek : MonoBehaviour
{
    public int speed;
    private Vector3 currentV;

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
        Vector3 position = camerapos - transform.position;

        //case 

        Vector3 vDisired = position.normalized * speed;
        Vector3 steering = vDisired - currentV;
        currentV += steering;
        transform.position += currentV * Time.deltaTime;
    }
}
