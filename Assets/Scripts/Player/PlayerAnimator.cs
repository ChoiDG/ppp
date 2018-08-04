using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
public class PlayerAnimator : PlayerBase
{
	protected override void Start ()
    {
        PlayerState.Subscribe(_ =>
        {
            switch(_)
            {
                case EState.Idle:
                    break;
                case EState.Walk:
                    break;
            }
        });
	}
}
