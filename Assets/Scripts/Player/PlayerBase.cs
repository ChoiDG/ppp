using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

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

        //RXEvent.Instance.playerCollision = gameObject.AddComponent<ObservableCollisionTrigger>();
        playerParameters.moveSpeed = 5.0f;
	}
}
