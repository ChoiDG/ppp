using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HedgehogTeam.EasyTouch;
using UniRx;

public class InputManager : MonoBehaviour
{
    public static Action<Gesture> SingleClickEventHandler = null;

    private Gesture gesture = null;

	// Use this for initialization
	void Start ()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                gesture = EasyTouch.current;
                if (gesture == null)
                    return;

                if(gesture.type == EasyTouch.EvtType.On_SimpleTap)
                {
                    if (SingleClickEventHandler == null)
                        return;

                    SingleClickEventHandler(gesture);
                }
            });
	}
	
}
