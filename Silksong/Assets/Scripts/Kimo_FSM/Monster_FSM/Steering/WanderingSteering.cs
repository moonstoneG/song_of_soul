using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WanderingSteering", menuName = "Steering/WanderingSteering")]
public class WanderingSteering : Steering
{
    public float wanderRadius=1;
    public float wanderJitter = 1;
    public float maxSpeed;
    public Vector2 targetPos=Vector2.right;
    public override void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        targetPos.x += Random.Range(-1, 2);
        targetPos.y += Random.Range(-1, 2);
        targetPos.Normalize();
        targetPos *= wanderRadius;
        Vector2 target = fsmManager.rigidbody2d.velocity.normalized * wanderJitter +targetPos;
        Vector2 desiredVelocity = target.normalized * maxSpeed;
        fsmManager.rigidbody2d.AddForce(desiredVelocity - fsmManager.rigidbody2d.velocity);
    }
}
