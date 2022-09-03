using System.Collections;
using UnityEngine;

public class ObjectWander : MonoBehaviour
{
    private int speed;
    private Vector3 currentV;
    private float pProduct;
    public float mass;
    public float minVX, maxVX;
    public float minVY, maxVY;
    private Vector3 rPOS;
    private LineRenderer lineRenderer;

    public GameObject wanderC;
    public float distanceC;

    private void Start()
    {
        currentV = Vector3.zero;
        StartCoroutine(RandomPos());
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RenderLineWander();

        Rotation();

        Seek();

        WanderC();
    }

    public void Rotation()
    {
        Vector3 rPos = rPOS;
        Vector2 distance = rPos - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, distance);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Seek()
    {
        Vector3 randomPos = rPOS;
        randomPos.z = 0;
        pProduct = Vector3.Distance(randomPos, transform.position);

        Vector3 position = randomPos - transform.position;

        Vector3 vDisired = position.normalized * (speed / mass);
        Vector3 steering = vDisired - currentV;
        currentV += steering;
        transform.position += currentV * Time.deltaTime;

        DistanceAplication();
    }

    private void DistanceAplication()
    {
        if (pProduct > 5)
        {
            speed = 10;
        }
        if (pProduct < 5 && pProduct > 2.5f)
        {
            speed = 5;
        }
        if (pProduct < 2.5f)
        {
            speed = 2;
        }
    }

    IEnumerator RandomPos()
    {
        while (true)
        {
            rPOS = new Vector3(Random.Range(minVX, maxVX), Random.Range(minVY, maxVY), 0);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void WanderC()
    {
        wanderC.transform.position = transform.position * distanceC;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, wanderC.transform.position - transform.position);
    }

    private void RenderLineWander()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, wanderC.transform.position);
        }
    }
}
