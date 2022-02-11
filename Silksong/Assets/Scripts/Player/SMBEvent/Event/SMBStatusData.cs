using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SMBStatusData : SMBEventTimeStamp
{
    public EPlayerStatus playerStatus;
    public bool statusIsActive;  
    public PlayerStatusDic.PlayerStatusFlag.WayOfChangingFlag wayOfChangingFlag;
    public override void EventActive()
    {
       // Debug.Log("event " + this.GetType());
       if(playerStatus!=0)
        PlayerController.Instance.playerAnimatorStatesControl.PlayerStatusDic.SetPlayerStatusFlag(playerStatus, statusIsActive, wayOfChangingFlag);
    }
}
