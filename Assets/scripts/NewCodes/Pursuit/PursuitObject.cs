using UnityEngine;

public class PursuitObject : SteeringBehaviors
{
    [Header("Pursuit Dependences")]
    public GameObject target;

    void Update()
    {
        Vector3 pursuit = this.Pursuit(target.transform.position);
        transform.position += pursuit * Time.deltaTime;
    }
}
