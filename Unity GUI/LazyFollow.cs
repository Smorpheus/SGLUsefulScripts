using UnityEngine;
using System.Collections;

public class LazyFollow : MonoBehaviour
{
	[SerializeField] private GameObject target;
	[SerializeField] private float speed = 20;

	// Update is called once per frame
	void LateUpdate () 
	{
		
		transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * speed);
		
	}
}
