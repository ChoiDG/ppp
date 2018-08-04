using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class RXEvent : Singleton<RXEvent>
{
    public Subject<EState> playerState = new Subject<EState>();
    public Subject<Vector3> move = new Subject<Vector3>();
    protected RXEvent()
    {

    }
    ~RXEvent()
    {

    }
}
