using System.Collections;
using UnityEngine;

public class WanderObject : SteeringBehaviors
{
    [Header ("Wander Dependences")]
    public GameObject circle;
    public Transform randomT;
    public float randomTime;

    void Start()
    {
        StartCoroutine(randomMove());
    }

    IEnumerator randomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomTime);
            this.angle = Random.Range(-180f, 180f);
            float randomX = Random.Range(-20, 20);
            float randomY = Random.Range(-20, 20);
            randomT.position = new Vector3(randomX, randomY, 0);
        }
    }

    void Update()
    {
        Vector3 seek = this.Seek(randomT.position);
        Vector3 wander = this.Wander();

        Vector3 steering = seek + wander;
        this.velocity = Vector3.ClampMagnitude(this.velocity + steering * Time.deltaTime, this.speed);
        transform.position += this.velocity * Time.deltaTime;

        circle.transform.localScale = new Vector3(this.radius, this.radius, 0);
        circle.transform.localPosition = transform.position + (this.velocity.normalized * this.centerOfCircle);
    }
}
