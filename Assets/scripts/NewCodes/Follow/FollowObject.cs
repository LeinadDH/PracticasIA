using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FollowObject : SteeringBehaviors
{
    public GameObject leader;
    public SteeringBehaviors leaderBehaviors;

    void Start()
    {
        leaderBehaviors = leader.GetComponent<SteeringBehaviors>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Seek(Follow(leaderBehaviors, leader)) * Time.deltaTime;
    }
}
