using UnityEngine;
using System.Collections;

public class LazyFollowRotation : MonoBehaviour 
{
	[SerializeField] private GameObject target;
	[SerializeField] private float maxAngleDistance;

	[SerializeField] private bool followX;
	[SerializeField] private bool followY;
	[SerializeField] private bool followZ;

	private void Start()
	{
		this.transform.rotation = target.transform.rotation;
	}

	private void LateUpdate()
	{

		if(followX == true) {
			UpdateXAngle();
		}

		if(followY == true) {
			UpdateYAngle();
		}

		if(followZ == true) {
			UpdateZAngle();
		}

	}

	private void UpdateXAngle()
	{
		float targetX = target.transform.eulerAngles.x;
		float myX = this.transform.eulerAngles.y;
		float distance = targetX - myX;

		if((distance) > 180) {
			targetX -= 360;
		} else if(distance < -180) {
			targetX += 360;
		}

		float distanceToTargetX = targetX - myX;

		if(distanceToTargetX > maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x - maxAngleDistance, 
				target.transform.eulerAngles.y,
				this.transform.eulerAngles.z);
			return;
		}

		if(distanceToTargetX < -maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x + maxAngleDistance, 
				target.transform.eulerAngles.y,
				this.transform.eulerAngles.z);
			return;
		}
	}

	private void UpdateYAngle()
	{
	
		float targetY = target.transform.eulerAngles.y;
		float myY = this.transform.eulerAngles.y;
		float distance = targetY - myY;

		if((distance) > 180) {
			targetY -= 360;
		} else if(distance < -180) {
			targetY += 360;
		}

		float distanceToTargetY = targetY - myY;

		if(distanceToTargetY > maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x, 
				target.transform.eulerAngles.y - maxAngleDistance,
				this.transform.eulerAngles.z);
			return;
		}

		if(distanceToTargetY < -maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x, 
				target.transform.eulerAngles.y + maxAngleDistance,
				this.transform.eulerAngles.z);
			return;
		}
	}

	private void UpdateZAngle()
	{
		float targetZ = target.transform.eulerAngles.z;
		float myZ = this.transform.eulerAngles.z;
		float distance = targetZ - myZ;

		if((distance) > 180) {
			targetZ -= 360;
		} else if(distance < -180) {
			targetZ += 360;
		}

		float distanceToTargetZ = targetZ - myZ;

		if(distanceToTargetZ > maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x, 
				target.transform.eulerAngles.y,
				this.transform.eulerAngles.z - maxAngleDistance);
			return;
		}

		if(distanceToTargetZ < -maxAngleDistance) {
			this.transform.eulerAngles = new Vector3(
				this.transform.eulerAngles.x, 
				target.transform.eulerAngles.y,
				this.transform.eulerAngles.z + maxAngleDistance);
			return;
		}
	}

}
