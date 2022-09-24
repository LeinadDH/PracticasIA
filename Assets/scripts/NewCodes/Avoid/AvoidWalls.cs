using UnityEngine;

public class AvoidWalls : SteeringBehaviors
{
    public Vector3 avoidForce;
    public bool enableAvoid = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            this.avoidGameObject = other.gameObject;
            avoidForce = this.Avoid();
            Debug.DrawRay(other.transform.position, avoidForce - other.transform.position, Color.blue);
        }
        if(other.tag == "Player")
        {
            if(enableAvoid)
            {
                this.avoidGameObject = other.gameObject;
                avoidForce = this.Avoid();
                Debug.DrawRay(other.transform.position, avoidForce - other.transform.position, Color.blue);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        avoidForce = Vector3.zero;
    }
}
