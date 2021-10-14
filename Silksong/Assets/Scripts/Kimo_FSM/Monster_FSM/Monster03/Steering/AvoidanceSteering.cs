using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvoidanceSteering", menuName = "Steering/AvoidanceSteering")]
public class AvoidanceSteering : Steering
{
    public float avoidForce=1;
    public float MAX_SEE_AHEAD = 2.0f;//��Ұ����
    public float MIN_RANGE = 1.0f;//���ϰ�����������
    public float outRange = 4;
    public RaycastHit2D ground;
    public Vector2 minDisPoint;
    public LayerMask layer;

    public override void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        fsmManager.rigidbody2d.AddForce(Project4(fsmManager));
    }
    public Vector2 Project4(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        Vector2 steeringForce = Vector2.zero;
        Vector2 toward = fsmManager.rigidbody2d.velocity.normalized;
        Vector2 vetical = new Vector2(-toward.y, toward.x);
        Vector2 pos = fsmManager.transform.position;
        Vector2 pointA = pos - (toward + vetical) * fsmManager.GetComponent<Collider2D>().bounds.extents.magnitude;
        Vector2 pointB = pos+toward*MAX_SEE_AHEAD+vetical* fsmManager.GetComponent<Collider2D>().bounds.extents.magnitude;
        Collider2D wall= Physics2D.OverlapArea(pointA, pointB, layer);
        Debug.DrawLine(pointA, pointB, Color.red);
        if (wall)
        {
            Vector2 ahead = pos + fsmManager.rigidbody2d.velocity.normalized * MAX_SEE_AHEAD;
            steeringForce = (ahead - (Vector2)wall.transform.position).normalized;
            steeringForce *= avoidForce;
        }
        Debug.DrawLine(pos, pos + steeringForce);
        return steeringForce;
    }
}
