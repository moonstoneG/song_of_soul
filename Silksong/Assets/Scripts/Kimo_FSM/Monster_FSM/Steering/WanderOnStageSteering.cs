using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WanderOnStageSteering", menuName = "Steering/WanderOnStageSteering")]
public class WanderOnStageSteering : Steering
{
    public Vector2 range;
    public float maxSpeed=2;
    public float force=1;
    public override void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        Vector2 steeringForce = Vector2.zero;
        Vector2 speed = Vector3.Project(fsmManager.GetComponent<Rigidbody>().velocity, fsmManager.transform.right);
        if (speed.magnitude < maxSpeed)
        {
            steeringForce += (Vector2)fsmManager.transform.right*force;
        }
        if ((fsmManager.transform.position.x > range.y && fsmManager.transform.rotation.y == 0) || (fsmManager.transform.position.x < range.x && fsmManager.transform.rotation.y != 0))
        {
            fsmManager.transform.Rotate(new Vector3(fsmManager.transform.rotation.x, fsmManager.transform.rotation.y == 0 ? 180 : -180, fsmManager.transform.rotation.z));
        }
        fsmManager.GetComponent<Rigidbody>().AddForce(steeringForce);
    }
}
