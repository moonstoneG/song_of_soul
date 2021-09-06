using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS_2D.FSM {
    public abstract class FSM_BaseTrigger
    {
        public FSM_TriggerID triggerID;
        /// <summary>
        /// 构造调用InitTrigger方法赋值triggerID初始值
        /// </summary>
        public FSM_BaseTrigger()
        {
            InitTrigger();
        }

        /// <summary>
        /// 初始化方法，必要操作为赋值triggerID(自行编码赋值)，可做其他操作实现
        /// </summary>
        protected abstract void InitTrigger();
        /// <summary>
        /// 是否达到该条件的判断方法
        /// </summary>
        /// <param name="fsm_Manager">管理相应状态类的fsm_manager</param>
        /// <returns></returns>
        public abstract bool IsTriggerReach(FSM_Manager fsm_Manager);
    }
}
