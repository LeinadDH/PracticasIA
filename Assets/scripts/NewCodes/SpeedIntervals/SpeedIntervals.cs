using UnityEngine;

public class SpeedIntervals : MonoBehaviour
{
    private float speed;

    [Header("Distance Intervals")]
    public float maxD;
    public float mediumD;
    public float minD;

    [Header("Speed Intervals")]
    public float vOne;
    public float vTwo;
    public float vThree;

    public float SpeedInterval(Vector3 targetPos)
    {
        float pProduct = Vector3.Distance(targetPos, transform.position);
        if (pProduct > maxD) speed = vOne;
        if (pProduct < maxD) if (pProduct > mediumD) speed = vTwo;
        else if (pProduct < minD) speed = vThree;
        return speed;
    }
}
