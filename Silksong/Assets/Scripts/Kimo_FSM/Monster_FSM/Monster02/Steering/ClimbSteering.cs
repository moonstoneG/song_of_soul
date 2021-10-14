using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClimbSteering", menuName = "Steering/ClimbSteering")]
public class ClimbSteering : Steering
{
    public float maxSpeed=2;
    public float force=10;
    ContactPoint2D[] points = new ContactPoint2D[3];
    public override void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {       
        Vector2 steeringForce = Vector2.zero;
        int n = fsmManager.GetComponent<Collider2D>().GetContacts(points);      
        if (n > 0)
        {
            Vector2 toward = ((Vector2)fsmManager.transform.position - points[n - 1].point);
            steeringForce += -toward * force;
            fsmManager.transform.right = toward;
            fsmManager.rigidbody2d.velocity = new Vector2(toward.y, -toward.x) * maxSpeed;
        }
        fsmManager.rigidbody2d.AddForce(steeringForce);
    }
}
