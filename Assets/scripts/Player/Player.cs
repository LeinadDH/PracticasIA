using System.Collections.Generic;
using UnityEngine;

public class Player : SteeringBehaviors
{
    [Header("Player Dependences")]
    public Vector3 FrameVelocity;
    Vector3 PrevPosition;
    private Vector3 target;
    public Queue<GameObject> collectables = new Queue<GameObject>();

    void Update()
    {
        Vector3 seek = this.Seek(target);
        transform.position += seek * Time.deltaTime;

        float pProduct = Vector3.Distance(target, transform.position);
        if (pProduct < 0.1f) speed = 0;

        VelocityPerFrame();
        InputMove();  
    }

    void VelocityPerFrame()
    {
        Vector3 actualFV = (transform.position - PrevPosition) / Time.deltaTime;
        FrameVelocity = Vector2.Lerp(FrameVelocity, actualFV, 0.1f);
        PrevPosition = transform.position;
    }

    void InputMove()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            this.speed = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("collectable"))
        {
            collectables.Enqueue(other.gameObject);
            other.gameObject.GetComponent<SteeringBehaviors>().distanceBehind = collectables.Count;
            other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if(collectables.Count > 0)
        {
            if (other.CompareTag("Enemy"))
            {
                collectables.Peek().GetComponent<FollowObject>().followEnable = false;
                collectables.Peek().transform.position = Vector3.zero;
                collectables.Peek().GetComponent<CircleCollider2D>().enabled = true;
                collectables.Dequeue();
                foreach (var stearingCode in collectables)
                {
                    stearingCode.GetComponent<SteeringBehaviors>().distanceBehind = stearingCode.GetComponent<SteeringBehaviors>().distanceBehind - 1;
                }
            }
        }
        
    }
}
