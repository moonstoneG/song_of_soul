using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

        
namespace AS_2D.FSM {
    public abstract class FSM_Manager:MonoBehaviour
    {

        //private Animator anim;
        //private AudioSource audio;
        /// /// <summary>
        /// 当前状态
        /// </summary>
        public FSM_BaseState currentState;
        /// <summary>
        /// 当前状态ID
        /// </summary>
        public FSM_StateID currentStateID;
        /// <summary>
        /// 默认状态
        /// </summary>
        public FSM_BaseState defaultState;
        /// <summary>
        /// 默认状态的ID
        /// </summary>
        public FSM_StateID defaultStateID;
        /// <summary>
        /// 当前状态机包含的所以状态列表
        /// </summary>
        public List<FSM_BaseState> states = new List<FSM_BaseState>();
        /// <summary>
        /// 配置状态列表及其对应条件列表的SO文件
        /// </summary>
        public List<StateConfig_SO> stateConfig_SO;

        public void ChangeState(FSM_TriggerID tiggerID) {
            FSM_StateID targetStateID = currentState.GetTriggerID(tiggerID);

            currentState.ExitState(this);
            if (targetStateID == FSM_StateID.NullStateID)
            {
                currentState = defaultState;

                return;
            }

            if (targetStateID == defaultStateID)
            {
                currentState = defaultState;
                return;
            }
            else {
                currentState = states.Find(p => p.stateID == targetStateID);
                currentStateID = targetStateID;
            }

            currentState.EnterState(this);
        }

        FSM_BaseState AddState(FSM_StateID stateID)
        {
            //Debug.Log(triggerID);

            Type type = Type.GetType(stateID + "_State");
            if (type == null)
            {
                Debug.LogError(stateID + "无法添加到"  + "的states列表");
                Debug.LogError("检查stateID枚举值及对应类名，对应枚举命加上“_State”，如枚举值为Idle，状态类名为Idle_State，便于配置加载；");
                return null;
            }
            else
            {
                FSM_BaseState temp = Activator.CreateInstance(type) as FSM_BaseState;
                states.Add(temp);
                return temp;
            }
        }
        /// <summary>
        /// 用于初始化状态机的方法，添加所有状态，及其条件映射表，获取部分组件等。Awake时执行，可不使用基类方法手动编码加载
        /// </summary>
        public virtual void InitStates() {
            //Debug.Log("initStates通过SO物体加载对应状态逻辑配置");
            //为当前状态管理添加所有配置状态
            for (int i = 0; i < stateConfig_SO.Count; i++)
            {
                
                FSM_BaseState temp =  AddState(stateConfig_SO[i].stateID);
                //添加对应状态的条件触发列表
                for (int j = 0; j < stateConfig_SO[i].trigger_IDs.Count; j++)
                {
                    temp.AddTriggers (stateConfig_SO[i].trigger_IDs[j]);
                }
                //为对应状态添加条件-状态的触发字典
                for (int k = 0; k < stateConfig_SO[i].map.Count; k++)
                {
                    //Debug.Log(stateConfig_SO[i].map[k].triggerID+"," + stateConfig_SO[i].map[k].stateID);
                    temp.AddTriggerStateID_map(stateConfig_SO[i].map[k].triggerID, stateConfig_SO[i].map[k].stateID);
                }
            }

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
            InitStates();
        }

        private void Start()
        {
            //默认状态设置
            defaultState = states.Find(p => p.StateID == defaultStateID);
            currentStateID = defaultStateID;
            currentState = defaultState;
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
            else {
                Debug.LogError("currentState为空");
            }
            
            
        }

    }
}
