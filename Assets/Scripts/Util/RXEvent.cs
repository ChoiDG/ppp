using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class RXEvent : Singleton<RXEvent>
{
    public Subject<EState> playerState = new Subject<EState>();
    public Subject<Vector3> move = new Subject<Vector3>();
    public Subject<Vector3> dragVari = new Subject<Vector3>();

    public Subject<Collider> collider = new Subject<Collider>();
    public IObservable<Collider> colliderObservable { get { return collider.AsObservable(); } }

    public ObservableCollisionTrigger playerCollision;
    protected RXEvent()
    {

    }
    ~RXEvent()
    {

    }
}
