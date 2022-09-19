using UnityEngine;

public class SeekObject : SteeringBehaviors
{
    [Header("Seek Dependencies")]
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
        Vector3 seek = this.Seek(target.transform.position);
        transform.position += seek * Time.deltaTime;
    }
}
