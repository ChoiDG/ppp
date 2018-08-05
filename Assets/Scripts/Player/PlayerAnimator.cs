using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

public class PlayerAnimator : PlayerBase
{
	protected override void Start ()
    {
        base.Start();
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
