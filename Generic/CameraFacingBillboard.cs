using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera m_Camera;

	private void OnEnable()
	{
		Face();
	}

	void LateUpdate()
	{
		Face();
	}

	private void Face()
	{
		if(m_Camera == null) {
			GameObject camGO = GameObject.FindGameObjectWithTag(Tags.CROSSHAIR_TARGETTER);
			if(m_Camera == null)
				return;
			m_Camera = camGO.GetComponent<Camera>();
		}
		
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.back,
		                 m_Camera.transform.rotation * Vector3.up);
	}
}