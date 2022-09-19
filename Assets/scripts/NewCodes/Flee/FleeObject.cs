using UnityEngine;

public class FleeObject : SteeringBehaviors
{
    [Header("Flee Dependencies")]
    public GameObject target;

    [Header("Speed Intervals")]
    SpeedIntervals speedIntervals;
    public bool enableInterval = false;

    private void Start()
    {
        speedIntervals = GetComponent<SpeedIntervals>();
    }

    void Update()
    {
        if (speedIntervals != null && enableInterval) this.speed = speedIntervals.SpeedInterval(target.transform.position);
        else this.speed = 2;
        Vector3 flee = this.Flee(target.transform.position);
        transform.position += flee * Time.deltaTime;
    }
}
