using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {


	/// <summary>
	/// The door collider.
	/// </summary>
	public Collider[] doorColliders;

	/// <summary>
	/// The animator.
	/// </summary>
	private Animator[] _animators;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake(){
		this._animators = this.GetComponentsInChildren<Animator> ();

		if (this._animators.Length != 2) {
			this.enabled = false;
			return;
		}

		if (this.doorColliders.Length != 2) {
			this.enabled = false;
			return;
		}
	}

	/// <summary>
	/// Opens the door.
	/// </summary>
	public void OpenDoor(){
		this._animators [0].SetTrigger (Tags.TOGGLE);
		this._animators [1].SetTrigger (Tags.TOGGLE);

		this.doorColliders [0].enabled = false;
		this.doorColliders [1].enabled = false;
	}

}
