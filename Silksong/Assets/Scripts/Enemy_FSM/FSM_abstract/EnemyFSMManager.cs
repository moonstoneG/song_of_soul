using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyFSMManager : MonoBehaviour
{

    //private Animator anim;
    //private AudioSource audio;
    public  Enemy_Parameters param;
    /// /// <summary>
    /// 当前状态
    /// </summary>
    public EnemyFSMBaseState currentState;
    public EnemyStates currentStateID;
    /// <summary>
    /// 默认状态
    /// </summary>
    public EnemyFSMBaseState defaultState;
    public EnemyStates defaultStateID;
    /// <summary>
    /// 当前状态机包含的所以状态列表
    /// </summary>
    public Dictionary<EnemyStates, EnemyFSMBaseState> statesDic = new Dictionary<EnemyStates, EnemyFSMBaseState>();
    /// <summary>
    /// 配置状态列表及其对应条件列表的SO文件
    /// </summary>
    public List<AS_2D.FSM.StateConfig_SO> stateConfig_SO;

    public void ChangeState(EnemyStates state)
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

    public EnemyFSMBaseState AddState(EnemyStates state)
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
            EnemyFSMBaseState temp = Activator.CreateInstance(type) as EnemyFSMBaseState;
            statesDic.Add(state,temp);
            return temp;
        }
    }
    public EnemyFSMBaseState AddState(EnemyStates state,EnemyFSMBaseState stateClass)
    {
        statesDic.Add(state, stateClass);
        return stateClass;
    }
    public void RemoveState(EnemyStates state)
    {
        if (statesDic.ContainsKey(state))
            statesDic.Remove(state);
    }
    /// <summary>
    /// 用于初始化状态机的方法，添加所有状态，及其条件映射表，获取部分组件等。Awake时执行，可不使用基类方法手动编码加载
    /// </summary>
    public virtual void InitStates()
    {
        //Debug.Log("initStates通过SO物体加载对应状态逻辑配置");
        //为当前状态管理添加所有配置状态
        //for (int i = 0; i < stateConfig_SO.Count; i++)
        //{

        //    EnemyFSMBaseState temp = AddState(stateConfig_SO[i].stateID);
        //    //添加对应状态的条件触发列表
        //    for (int j = 0; j < stateConfig_SO[i].trigger_IDs.Count; j++)
        //    {
        //        temp.AddTriggers(stateConfig_SO[i].trigger_IDs[j]);
        //    }
        //    //为对应状态添加条件-状态的触发字典
        //    for (int k = 0; k < stateConfig_SO[i].map.Count; k++)
        //    {
        //        //Debug.Log(stateConfig_SO[i].map[k].triggerID+"," + stateConfig_SO[i].map[k].stateID);
        //        temp.AddTriggerStateID_map(stateConfig_SO[i].map[k].triggerID, stateConfig_SO[i].map[k].stateID);
        //    }
        //}

        ////组件获取
        //if (GetComponent<Animator>()!= null)
        //{
        //    anim = GetComponent<Animator>();
        //}
        //if (GetComponent<AudioSource>()!=null)
        //{
        //    audio = GetComponent<AudioSource>();
        //}

    }

    private void Awake()
    {
        if (!param.rigidbody)
            param.rigidbody = GetComponent<Rigidbody2D>();
        if (!param.animator)
            param.animator = GetComponent<Animator>();
        InitStates();
    }

    private void Start()
    {
        //默认状态设置
        currentStateID = defaultStateID;
        currentState = statesDic[currentStateID];

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
