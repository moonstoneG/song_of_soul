using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CreateAssetMenu(fileName ="New Steering",menuName ="Steering")]
public class Steering : ScriptableObject
{
    //steering中只保存共有信息（可以说就是值类型的数据），其余信息应该由fsmmanage提供
    public float weight = 1;
    public virtual void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
    }
}
