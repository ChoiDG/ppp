using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;
public class PlayerCollision : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        this.OnCollisionEnterAsObservable()
            .Subscribe(_ => Debug.Log("trigger"));
	}
}
