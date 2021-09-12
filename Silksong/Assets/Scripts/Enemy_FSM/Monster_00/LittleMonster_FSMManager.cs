using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMonster_FSMManager :EnemyFSMManager
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            EventsManager.Instance.Invoke(this.gameObject, EventType.onEnemyHitWall);
        }
    }
}
