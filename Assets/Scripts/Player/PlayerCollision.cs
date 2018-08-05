using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
public class PlayerCollision : PlayerBase
{
	// Use this for initialization
	protected override void Start ()
    {
        RXEvent.Instance.playerCollision.OnCollisionEnterAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("collider");
            });
	}
}
