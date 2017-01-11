using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfViewRetocado : MonoBehaviour {

	//Audio
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip alarma;


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
                //float dstToTarget = transform.position.sqrMagnitude-target.position.sqrMagnitude;
		float dstToTarget=Vector3.Distance(transform.position, target.position);
                timer+=Time.time;

                if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)&&timer>=5f) {
					visibleTargets.Add (target);
                        Debug.Log("Visto");
                         if (target.CompareTag("Grande")){

                               Pausa.vecesVisto++;
                               target.transform.position=Movimiento_Grande.checkpointGrande;
						sonido.PlayOneShot(alarma);
                           }

                           if (target.CompareTag("Pequeño"))
                           {
                               Debug.Log("Visto");
                               Pausa.vecesVisto++;
                               target.transform.position = Movimiento_Pequeño.checkpointPequeño;
						sonido.PlayOneShot(alarma);

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
