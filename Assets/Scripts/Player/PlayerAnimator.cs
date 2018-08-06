using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

public enum EState
{
    Idle,
    Walk,
    Run,
    Jump,
    Die,
    Fall
}

public class PlayerAnimator : MonoBehaviour
{
    Animator animator = null;
	void Start ()
    {
        animator = GetComponent<Animator>();
        RXEvent.Instance.playerState.Subscribe(_ =>
        {
            switch(_)
            {
                case EState.Idle:
                    Debug.Log("idle");
                    break;
                case EState.Walk:
                    animator.SetBool("Walk", true);
                    break;
                default:
                    Debug.Log("other");
                    break;
            }
        });
	}
}
