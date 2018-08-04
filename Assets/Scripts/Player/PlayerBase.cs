using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
public enum EState
{
    Idle,
    Walk,
    Run,
    Jump,
    Die,
    Fall
}

public struct PlayerParameters
{
    public float moveSpeed;
}

public class PlayerBase : MonoBehaviour
{
    protected Animator animator = null;
    protected CharacterController characterController = null;
    
    protected PlayerParameters playerParameters;
	// Use this for initialization
	protected virtual void Start ()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        
        playerParameters.moveSpeed = 5.0f;
	}
}
