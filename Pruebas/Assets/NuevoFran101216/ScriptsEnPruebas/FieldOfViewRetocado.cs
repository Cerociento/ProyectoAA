using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfViewRetocado : MonoBehaviour {

	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;
	public float timer=0f;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start() {
		StartCoroutine ("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void FindVisibleTargets() {
		visibleTargets.Clear ();
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius [i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
				float dstToTarget = transform.position.sqrMagnitude-target.position.sqrMagnitude;
				timer+=Time.time;
				if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)&&timer>=5f) {
					visibleTargets.Add (target);
					if(target.CompareTag("Player")){
						Debug.Log("Visto");
						//Añade al menú las veces que ha sido visto
						vecesMuerto.vecesVisto++;

						//Cambiar por el checkpoint correspondiente
						target.transform.position=Vector3.zero;
					}
				}
			}else{
				timer=0;
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}