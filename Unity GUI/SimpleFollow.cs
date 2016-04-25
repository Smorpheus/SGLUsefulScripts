using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour 
{
	[SerializeField] bool trackX;
	[SerializeField] bool trackY;
	[SerializeField] bool trackZ;

	public GameObject target;

	private void LateUpdate()
	{
		if(target != null) {
			Vector3 newPos = this.transform.position;
			if (trackX)
				newPos.x = target.transform.position.x;

			if(trackY)
				newPos.y = target.transform.position.y;

			if(trackZ)
				newPos.z = target.transform.position.z;

			this.transform.position = newPos;
		}
	}
}
