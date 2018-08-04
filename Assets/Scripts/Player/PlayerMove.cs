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
        InputManager.DragEventHandler += OnRecvDragEvent;

        RXEvent.Instance.move.Subscribe(pos =>
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            moveCoroutine = StartCoroutine(IEMove(pos));
        });

        RXEvent.Instance.dragVari.Subscribe(variation =>
        {
            characterController.Move(variation);
        });
	}

    IEnumerator IEMove(Vector3 pos)
    {
        yield return null;
        float sqrRemainingDistance = (transform.position - pos).sqrMagnitude;

        RXEvent.Instance.playerState.OnNext(EState.Walk);
        while (sqrRemainingDistance > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                pos,
                playerParameters.moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnRecvSingleClickMsg(Gesture gesture)
    {
        ray = Camera.main.ScreenPointToRay(gesture.position);
        Physics.Raycast(ray, out raycastHit);
        RXEvent.Instance.move.OnNext(new Vector3(raycastHit.point.x, 0, raycastHit.point.z));
    }

    private void OnRecvDragEvent(Gesture gesture)
    {
        RXEvent.Instance.dragVari.OnNext(new Vector3(gesture.deltaPosition.x, 1, gesture.deltaPosition.y));
    }
}
