using UnityEditor;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    [Header("Steering Dependencies")]
    public float speed;
    public Vector3 velocity;
    public float Mass;

    [Header("Seek & Flee")]
    public Vector3 desiredVelocity;

    [Header("Wander")]
    public bool drawRay;
    public float centerOfCircle;
    [Range(2, 20f)]
    public float radius;
    [Range(-180f, 180f)]
    public float angle;

    [Header("Pursuit")]
    public Vector3 VPF; //Velocity per Frame
    public Vector3 tempPosition;
    public Vector3 futurePosition;
    public float changeInT;

    [Header("Follow Leader")]
    public float distanceBehind;

    [Header("Avoid")]
    public float maxSeeAhead;
    public float maxAvoidForce;
    public GameObject avoidGameObject;

    public Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distance = targetPos - transform.position;
        desiredVelocity = distance.normalized * speed;
        Vector3 steering = desiredVelocity - velocity;
        return steering;   
    }

    public Vector3 Flee(Vector3  targetPos)
    {
        Vector3 steering = Seek(targetPos);
        return steering * -1;
    }

    public Vector3 Wander()
    {
        Vector3 circleD = transform.position + (velocity.normalized * centerOfCircle);
        Vector3 rotation = Quaternion.AngleAxis(angle, Vector3.forward) * velocity.normalized;
        Vector3 circlePos = circleD + (rotation * radius / 8.1f);

        if(drawRay)
        {
            Debug.DrawRay(transform.position, circleD - transform.position, Color.red);
            Debug.DrawRay(circleD, circlePos - circleD, Color.green);
        }

        return Seek(circlePos);
    }

    public Vector3 Pursuit(Vector3 targetPos)
    {
        Vector3 actualVelocity = (targetPos - tempPosition) / Time.deltaTime;
        VPF = Vector3.Lerp(VPF, actualVelocity, 0.1f);
        tempPosition = targetPos;
        futurePosition = targetPos + (VPF * changeInT);
        return Seek(futurePosition);
    }

    public Vector3 Evade(Vector3 targetPos)
    {
        Vector3 steering = Pursuit(targetPos);
        return steering * -1;
    }

    public Vector3 Follow(SteeringBehaviors LeaderBehaviors, GameObject Leader)
    {
        Vector3 tv = LeaderBehaviors.desiredVelocity * -1;
        tv = tv.normalized * distanceBehind;
        Vector3 behind = Leader.transform.position + tv;
        return behind;
    }

    public Vector3 Avoid()
    {
        Vector3 seeAhead = transform.position + (velocity.normalized * maxSeeAhead / 2);
        Vector3 avoidanceForce = seeAhead - avoidGameObject.transform.position;
        avoidanceForce = (avoidanceForce.normalized) * maxAvoidForce;

        return avoidanceForce;
    }
}
