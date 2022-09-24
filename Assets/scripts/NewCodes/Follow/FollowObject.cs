using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : SteeringBehaviors
{
    [Header("Follow Dependencies")]
    public GameObject leader;
    public SteeringBehaviors leaderBehaviors;

    [HideInInspector]
    public bool followEnable = false;
    [HideInInspector]
    public bool enableFlee = false;
    [HideInInspector]
    public bool enablePursuit = false;

    [Header("Speed Intervals")]
    SpeedIntervals speedIntervals;
    public bool enableInterval = false;

    private SpriteRenderer sprite;

    //Avoid Walls
    AvoidWalls avoidWalls;

    void Start()
    {
        leader = GameObject.FindGameObjectWithTag("Player");
        leaderBehaviors = leader.GetComponent<SteeringBehaviors>();
        speedIntervals = GetComponent<SpeedIntervals>();
        avoidWalls = GetComponentInChildren<AvoidWalls>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enablePursuit)
        {
            FollowLeader();
            FleePlayer();
        }
        PursuitPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            followEnable = true;
        }
        if(collision.CompareTag("Wall"))
        {
            transform.position = Vector3.zero;
        }
    }

    void FollowLeader()
    {
        if (followEnable) transform.position += Seek(Follow(leaderBehaviors, leader)) * Time.deltaTime;
        else if (!followEnable) this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    void FleePlayer()
    {
        if(!followEnable && enableFlee)
        {
            if (speedIntervals != null && enableInterval) this.speed = speedIntervals.SpeedInterval(leader.transform.position);
            else this.speed = 0;
            Vector3 flee = this.Flee(leader.transform.position);
            Vector3 avoid = avoidWalls.avoidForce;
            Vector3 Steering = flee + avoid;
            transform.position += Steering * Time.deltaTime;
        }
        if(followEnable && enableFlee)
        {
            this.speed = 5;
        }
        else if(!followEnable && enableFlee && avoidWalls.enableAvoid)
        {
            speed = 0;
        }
    }

    void PursuitPlayer()
    {
        if(enablePursuit)
        {
            this.speed = 4;
            followEnable = false;
            enableFlee = false;
            enableInterval = false;
            sprite.color = Color.red;


            transform.position += Pursuit(leader.transform.position) * Time.deltaTime;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            this.gameObject.tag = "Enemy";
        }
    }


}
