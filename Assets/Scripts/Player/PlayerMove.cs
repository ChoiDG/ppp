using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using HedgehogTeam.EasyTouch;
public class PlayerMove : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;

    private Coroutine moveCoroutine = null;

	// Use this for initialization
	void Start ()
    {
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
            Debug.Log(variation);
            //characterController.Move(variation);
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
                5.0f * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.position);
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
