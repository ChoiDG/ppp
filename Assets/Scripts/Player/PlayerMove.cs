using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using HedgehogTeam.EasyTouch;
public class PlayerMove : PlayerBase
{
    private Ray ray;
    private RaycastHit raycastHit;

    private Coroutine moveCoroutine = null;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();

        InputManager.SingleClickEventHandler += OnRecvSingleClickMsg;
        move.Subscribe(_ =>
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            moveCoroutine = StartCoroutine(IEMove(_));
        });
	}

    IEnumerator IEMove(Vector3 pos)
    {
        yield return null;
        float sqrRemainingDistance = (transform.position - pos).sqrMagnitude;
        while(sqrRemainingDistance > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                pos,
                playerParameters.moveSpeed * Time.deltaTime);

            playerState.OnNext(EState.Walk);
            yield return null;
        }
    }

    private void OnRecvSingleClickMsg(Gesture gesture)
    {
        ray = Camera.main.ScreenPointToRay(gesture.position);
        Physics.Raycast(ray, out raycastHit);
        move.OnNext(new Vector3(raycastHit.point.x, 0, raycastHit.point.z));
    }
}
