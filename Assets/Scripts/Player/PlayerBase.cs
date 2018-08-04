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
    protected Subject<EState> playerState = new Subject<EState>();
    protected IObservable<EState> PlayerState
    {
        get
        {
            return playerState;
        }
    }

    protected Animator animator = null;
    protected CharacterController characterController = null;

    protected Subject<Vector3> move = new Subject<Vector3>();
    
    protected PlayerParameters playerParameters;
	// Use this for initialization
	protected virtual void Start ()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();


        playerParameters.moveSpeed = 5.0f;
	}
}
