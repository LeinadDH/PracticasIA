using UnityEngine;

public class EvadeObject : SteeringBehaviors
{
    [Header("Evade Dependences")]
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
        Vector3 evade = this.Evade(target.transform.position);
        transform.position += evade * Time.deltaTime;
    }
}
