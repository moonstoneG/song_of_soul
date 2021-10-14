using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PursuitSteering", menuName = "Steering/PursuitSteering")]
public class PursuitSteering : Steering
{
    public Transform target;
    public float maxSpeed=2;
    public float force;
    public float maxForce=2;
    public Vector2 desiredVelocity;

    public override void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        if (!target)
        {
            GameObject[] a = GameObject.FindGameObjectsWithTag("Player");
            target = a[0].transform;
        }
        Vector2 desiredVelocity = (target.position - fsmManager.transform.position).normalized * maxSpeed;
        Vector2 steeringForce = (desiredVelocity - fsmManager.rigidbody2d.velocity);
        if (steeringForce.magnitude > maxForce) steeringForce = steeringForce.normalized * maxForce;
        Debug.DrawLine(fsmManager.transform.position, (Vector2)fsmManager.transform.position + steeringForce, Color.green);
        fsmManager.rigidbody2d.AddForce(steeringForce);
    }
}
