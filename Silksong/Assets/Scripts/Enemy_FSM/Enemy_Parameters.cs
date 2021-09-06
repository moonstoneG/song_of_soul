using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy_Parameters
{
    public float IdleTime;
    public bool isFaceRight;

    public Vector3 moveDirection;
    public float partrolTime;
    public float partrolSpeed;
    public float chaseSpeed;
    public Rigidbody2D rigidbody;
    public Animator animator;
}
