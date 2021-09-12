using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_State : EnemyFSMBaseState
{
    public bool isBack;
    public Vector3 moveSpeed;

    public  float rayToGroundDistance;


    public override void Act_State(EnemyFSMManager fSM_Manager)
    {
        fsmManager = fSM_Manager;
        Move();
        UpdateFace();
        if(isBack)
        {
            DetectionPlatformBoundary();
        }
    }
    public override void EnterState(EnemyFSMManager fSM_Manager)
    {
        fsmManager = fSM_Manager;
        if (isBack)
        {
            Turn();
            var rayHit = Physics2D.Raycast(fsmManager.transform.position + new Vector3((moveSpeed.x > 0 ? 1 : -1), 0, 0) * fsmManager.GetComponent<SpriteRenderer>().sprite.rect.width / 2, Vector2.down);
            rayToGroundDistance = rayHit.distance;
        }
    }
    protected override void InitState()
    {
        base.InitState();
        stateID = EnemyStates.Enemy_Patrol_State;

        if (isBack)
        {
            EventsManager.Instance.AddListener(fsmManager.gameObject, EventType.onEnemyHitWall, HitWall);
        }

       
        
    }
    private void Turn()
    {
        moveSpeed.x *= -1;
        
    }
    private void UpdateFace()
    {
        if(moveSpeed.x>0)
            fsmManager.transform.localScale = new Vector3(-1, 1, 1);
        else
            fsmManager.transform.localScale = new Vector3(1, 1, 1);
    }
    private void HitWall()
    {
        
        Turn();
    }
    private void Move()
    {
        fsmManager.rigidbody.velocity = moveSpeed;
    }
    private void DetectionPlatformBoundary()
    {
        var rayHit=Physics2D.Raycast(fsmManager.transform.position +new Vector3((moveSpeed.x>0?1:-1),0,0) * fsmManager.GetComponent<SpriteRenderer>().sprite.rect.width / 2, Vector2.down);
        if(rayHit.distance>rayToGroundDistance)
        {
            Turn();
        }
    }

    private void ChangeFlyDir()
    {
        Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        moveSpeed = randDir.normalized * moveSpeed.magnitude;
    }


}
