using UnityEngine;
using System.Collections;

public class TimedTrap : MonoBehaviour {

	//Audio
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip pinchosEntran;
	[SerializeField]
	AudioClip pinchosSalen;

	/// <summary>
	/// Is this trap always active?
	/// </summary>
	public bool alwaysActive = false;

	/// <summary>
	/// How long must this trap be deactivated
	/// </summary>
	[Range(0.0f, 60.0f)]
	public float deactivatedTime = 2.0f;

	/// <summary>
	/// How long should this trap be activated
	/// </summary>
	[Range(0.0f, 60.0f)]
	public float activatedTime = 1.0f;

	/// <summary>
	/// Initial delay
	/// </summary>
	[Range(0.0f, 60.0f)]
	public float initialDelay = 0.0f;

	/// <summary>
	/// The initially activated.
	/// </summary>
	public bool initiallyActivated = false;

	/// <summary>
	/// The death trigger.
	/// </summary>
	public Collider deathTrigger;

	/// <summary>
	/// The animator.
	/// </summary>
	private Animator _animator;

	/// <summary>
	/// The death trigger activation delay.
	/// </summary>
	private float _deathTriggerActivationDelay;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake(){
		this._animator = this.GetComponent<Animator> ();

		if (this._animator == null) {
			Debug.LogError ("No Animator component found in " + this.name);
			this.enabled = false;
			return;
		}

		if (this.deathTrigger == null) {
			Debug.LogError ("No Trigger Collider component found in " + this.name);
			this.enabled = false;
			return;
		}

		if (this.initiallyActivated || this.alwaysActive) {
			this._animator.SetTrigger (Tags.INIT);
			this.deathTrigger.enabled = true;
		}

		this._deathTriggerActivationDelay = 0.667f / Tags.ACTIVATINGSPEEDMULTIPLIER;

		this._animator.SetFloat (Tags.ACTIVATINGSPEED, Tags.ACTIVATINGSPEEDMULTIPLIER);
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start () {
		if (!this.alwaysActive) {
			this.StartCoroutine (InitAnimation ());
		}
	}

	/// <summary>
	/// Inits the animation.
	/// </summary>
	/// <returns>The animation.</returns>
	private IEnumerator InitAnimation(){
		yield return new WaitForSeconds (this.initialDelay);
		if (!this.initiallyActivated) {
			this.StartCoroutine (DeactivateAnimation ());
		} else {
			this.StartCoroutine (ActivateAnimation ());
		}
	}

	/// <summary>
	/// Activates the trap.
	/// </summary>
	/// <returns>The animation.</returns>
	private IEnumerator ActivateAnimation(){
		yield return new WaitForSeconds (this._deathTriggerActivationDelay);
		this.deathTrigger.enabled = true;
		yield return new WaitForSeconds (this.activatedTime);
		this._animator.SetTrigger (Tags.TOGGLE);
		this.StartCoroutine (DeactivateAnimation ());
		sonido.PlayOneShot(pinchosEntran);
	}

	/// <summary>
	/// Deactivates the trap.
	/// </summary>
	/// <returns>The animation.</returns>
	private IEnumerator DeactivateAnimation(){
		this.deathTrigger.enabled = false;
		yield return new WaitForSeconds (this.deactivatedTime);
		this._animator.SetTrigger (Tags.TOGGLE);
		this.StartCoroutine (ActivateAnimation ());
		sonido.PlayOneShot(pinchosSalen);
	}

	/// <summary>
	/// Deactivate this instance.
	/// </summary>
	private void Deactivate(){
		this.StopAllCoroutines ();
		this.deathTrigger.enabled = false;
		this._animator.ResetTrigger (Tags.TOGGLE);
		this._animator.SetTrigger (Tags.DEACTIVATE);
	}

	/// <summary>
	/// Forces the toggle (only if the trap is Always Active).
	/// </summary>
	private void ForceToggle(){
		if (!this.alwaysActive) {
			Debug.LogWarning ("Can't force toggle if this instance is playing Coroutines.");
			return;
		}

		if (this.deathTrigger.enabled) {
			this.deathTrigger.enabled = false;
			this._animator.SetTrigger (Tags.TOGGLE);
		} else {
			this.deathTrigger.enabled = true;
			this._animator.SetTrigger (Tags.TOGGLE);
		}

	}

}
