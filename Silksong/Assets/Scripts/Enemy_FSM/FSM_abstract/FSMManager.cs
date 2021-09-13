using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



public abstract class FSMManager<T1,T2> : MonoBehaviour
{

    public Animator animator;
    public AudioSource audio;
    public Rigidbody2D rigidbody;
    /// /// <summary>
    /// 当前状态
    /// </summary>
    public FSMBaseState<T1,T2> currentState;
    [DisplayOnly]
    public T1 currentStateID;
    /// <summary>
    /// 默认状态
    /// </summary>
    public FSMBaseState<T1,T2> defaultState;
    [DisplayOnly]
    public T1 defaultStateID;
    /// <summary>
    /// 当前状态机包含的所以状态列表
    /// </summary>
    public Dictionary<T1, FSMBaseState<T1,T2>> statesDic = new Dictionary<T1, FSMBaseState<T1,T2>>();
    /// <summary>
    /// 配置状态列表及其对应条件列表的SO文件
    /// </summary>


    public void ChangeState(T1 state)
    {
        if (currentState != null)
            currentState.ExitState(this);
        if (statesDic.ContainsKey(state))
        {
            currentState = statesDic[state];
            currentStateID = state;
        }
        else
        {
            Debug.LogError("敌人状态不存在");
        }
        currentState.EnterState(this);
    }

    public FSMBaseState<T1,T2> AddState(T1 state)
    {
        //Debug.Log(triggerID);

        Type type = Type.GetType("Enemy"+state + "State");
        if (type == null)
        {
            Debug.LogError(state + "无法添加到" + "的states列表");
            Debug.LogError("检查stateID枚举值及对应类名，对应枚举命加上“_State”，如枚举值为Idle，状态类名为Idle_State，便于配置加载；");
            return null;
        }
        else
        {
            FSMBaseState<T1,T2> temp = Activator.CreateInstance(type) as FSMBaseState<T1,T2>;
            statesDic.Add(state,temp);
            return temp;
        }
    }
    public FSMBaseState<T1,T2> AddState(T1 state,FSMBaseState<T1,T2> stateClass)
    {
        statesDic.Add(state, stateClass);
        return stateClass;
    }
    public void RemoveState(T1 state)
    {
        if (statesDic.ContainsKey(state))
            statesDic.Remove(state);
    }
    /// <summary>
    /// 用于初始化状态机的方法，添加所有状态，及其条件映射表，获取部分组件等。Awake时执行，可不使用基类方法手动编码加载
    /// </summary>
    /// 

    public virtual void InitWithScriptableObject()
    {
    }
    public virtual void InitStates()
    {


        InitWithScriptableObject();
        ////组件获取
        if (GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
        if (GetComponent<AudioSource>() != null)
        {
            audio = GetComponent<AudioSource>();
        }
        if(GetComponent<Rigidbody2D>()!=null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

    }

    private void Awake()
    {
        statesDic.Clear();
        InitStates();
    }

    private void Start()
    {
        
        //默认状态设置
        currentStateID = defaultStateID;
        //currentState = statesDic[currentStateID];
        ChangeState(currentStateID);
    }

    private void Update()
    {

        if (currentState != null)
        {
            //执行状态内容
            currentState.Act_State(this);
            //检测状态条件列表
            currentState.TriggerState(this);
        }
        else
        {
            Debug.LogError("currentState为空");
        }
    }

}


public class EnemyFSMManager : FSMManager<EnemyStates, EnemyTrigger> 
{
    public List<Enemy_State_SO_Config> stateConfigs;
    public override void InitWithScriptableObject()
    {
        for (int i = 0; i < stateConfigs.Count; i++)
        {
            FSMBaseState<EnemyStates, EnemyTrigger> tem = stateConfigs[i].stateConfig;
            tem.ClearTriggers();
            foreach (var value in stateConfigs[i].triggerList)
            {
                tem.AddTriggers(value as FSMBaseTrigger<EnemyStates, EnemyTrigger>);
            }
            statesDic.Add(stateConfigs[i].stateID, tem);
        }
    }
}
