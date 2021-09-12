using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Reflection;

[CreateAssetMenu(fileName = "StateConfig_SO", menuName = "SO敌人配置", order = 2)]
public class State_SO_Config : ScriptableObject
{
    [HideInInspector]
    [SerializeReference]
    public EnemyStates lastStateID;
    [HideInInspector]
    [SerializeReference]
    public EnemyTrigger lastTriggerID;
    [Header("--------------------State Config Area------------------------")]
    public EnemyStates stateID;
    [SerializeReference]
    public EnemyFSMBaseState stateConfig;
    [Header("----------------------Trigger Config Area----------------------")]
    [Space(20)]
    public EnemyTrigger triggerID;
    [SerializeReference]
    public System.Object triggerConfig;
    [Header("-----------------------Triggers List Area----------------------")]
    [Space(20)]
    [SerializeReference]
    public List<System.Object> triggerList;

    private Type triggerType;
    private Type stateType;

    private void Awake()
    {
        lastStateID = stateID;
        stateType = Type.GetType(stateID.ToString());
        if (stateType != null)
            stateConfig = Activator.CreateInstance(stateType) as EnemyFSMBaseState;
        else
            Debug.LogError("找不到所对应的State，请检查枚举名称是否与类名一致。");


        lastTriggerID = triggerID;
        triggerType = Type.GetType(triggerID.ToString());
        if (triggerType != null)
            triggerConfig = Activator.CreateInstance(triggerType);
        else
            Debug.LogError("找不到所对应的Trigger，请检查枚举名称是否与类名一致。");
    }

    [CustomEditor(typeof(State_SO_Config))]
    public class State_SO_Config_Editor:Editor
    {
       
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            State_SO_Config config = target as State_SO_Config;
            if(config.lastStateID!=config.stateID)
            {
                config.lastStateID = config.stateID;
                config.stateType = Type.GetType(config.stateID.ToString());
                if (config.stateType != null)
                    config.stateConfig = Activator.CreateInstance(config.stateType) as EnemyFSMBaseState;
                else
                    Debug.LogError("找不到所对应的State，请检查枚举名称是否与类名一致。");

            }
            if (config.lastTriggerID != config.triggerID)
            {
                config.lastTriggerID = config.triggerID;
                config.triggerType = Type.GetType(config.triggerID.ToString());
                if (config.triggerType != null)
                    config.triggerConfig = Activator.CreateInstance(config.triggerType);
                else
                    Debug.LogError("找不到所对应的Trigger，请检查枚举名称是否与类名一致。");

            }
            if(GUILayout.Button("Add to List"))
            {
                config.triggerList.Add(CloneObject(config.triggerConfig));
            }
        }


        System.Object DeepCloneObject(System.Object obj)
        {
            if (obj == null)
                return null;
            Type type = obj.GetType();
            System.Object outObj = Activator.CreateInstance(type);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(PropertyInfo property in properties)
            {
                if(property.CanWrite)
                {
                    if(property.PropertyType.IsValueType|| property.PropertyType.IsEnum|| property.PropertyType.Equals(typeof(String)))
                    {
                        property.SetValue(outObj, property.GetValue(obj,null),null);
                    }
                    else
                    {
                        System.Object insideValue = property.GetValue(obj, null);
                        if(insideValue==null)
                        {
                            property.SetValue(outObj, null, null);
                        }else
                        {
                            property.SetValue(outObj, DeepCloneObject(insideValue), null);
                        }
                    }
                }
            }
            foreach (FieldInfo field in fields)
            {
             
            if(field.FieldType.IsValueType||field.FieldType.IsEnum||field.FieldType.Equals(typeof(string)))
                {
                    field.SetValue(outObj, field.GetValue(obj));
                }else
                {
                    var insideField = field.GetValue(obj);
                    if(insideField==null)
                    {
                        field.SetValue(outObj, null);
                    }else
                    {
                        field.SetValue(outObj, DeepCloneObject(insideField));
                    }
                }
            }
            return outObj;
        }
        System.Object CloneObject(System.Object obj)
        {
            if (obj == null)
                return null;
            Type type = obj.GetType();
            System.Object outObj = Activator.CreateInstance(type);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(outObj, property.GetValue(obj, null), null);
                }
            }
            foreach (FieldInfo field in fields)
            {
                field.SetValue(outObj, field.GetValue(obj));
            }
            return outObj;
        }
    }
}


public class DisplayOnly:PropertyAttribute{ }

[CustomPropertyDrawer(typeof(DisplayOnly))]
public class DisplayOnlyDraw:PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, true);
        GUI.enabled = true;
    }
}

