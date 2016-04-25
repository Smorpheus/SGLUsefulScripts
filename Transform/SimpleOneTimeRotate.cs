using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SimpleOneTimeRotate : MonoBehaviour {

	public float rotations;
	public float duration;
	public bool rotateOnStart;

	private Tweener rotateTween;

	private void Start()
	{
		if(rotateOnStart == true) {
			Rotate();
		}
	}

	public void KillRotation()
	{
		if(rotateTween != null)
			rotateTween.Kill();
	}

	public void Rotate()
	{
		rotateTween = DOTween.To (() => transform.rotation, x => transform.rotation = x, new Vector3(0.0f, 360.0f * rotations, 0.0f), duration);
	}
	


}
