using UnityEngine;
using System.Collections;

public class FFTBallPhysics : MonoBehaviour 
{
    [System.Serializable]
    public enum PhysicsCalculationType
    {
        BALL_MODEL,
        PLANE_MODEL
    }

    public FFTController controller;
    public float velocityForceScalar = 1;
    public PhysicsCalculationType physicsType;

    private VelocityEstimator[] velocityEstimators;

	// Use this for initialization
	void Start () 
    {
        velocityEstimators = controller.GetComponentsInChildren<VelocityEstimator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 overallForce = CalculateOverallForce();
        if (overallForce != Vector3.zero)
        {
			Debug.Log("Force : " + overallForce);
			rigidbody.velocity = Vector3.Reflect(rigidbody.velocity, overallForce.normalized);
			if (rigidbody.velocity.y < 0) {
				rigidbody.velocity = -rigidbody.velocity;
			}
            rigidbody.AddForce(overallForce, ForceMode.Force);
			
        }
	}

    private Vector3 CalculateOverallForce()
    {
        Vector3 forceSum = Vector3.zero;
		if (physicsType == PhysicsCalculationType.BALL_MODEL) {
			forceSum += CalculateTrampolineForceBallModel();
		} else if (physicsType == PhysicsCalculationType.PLANE_MODEL) {
			forceSum += CalculateTrampolineForcePlaneModel();
		}
        return forceSum;
    }
	
	private Vector3 CalculateTrampolineForceBallModel() {
        SphereCollider myCollider = this.collider as SphereCollider;
		Vector3 forceSum = Vector3.zero;
		foreach (VelocityEstimator estimator in velocityEstimators)
        {
            Vector3 positionDelta = transform.position - estimator.position;
            float distance = positionDelta.magnitude;
            SphereCollider otherCollider = estimator.collider as SphereCollider;
            //TODO : Use squared distances to be more efficient?
            if (distance < myCollider.radius + otherCollider.radius)
            {
                forceSum += positionDelta.normalized * estimator.velocity.magnitude * velocityForceScalar;
            }
        }
		return forceSum;
	}
	
	private Vector3 CalculateTrampolineForcePlaneModel() {
		Vector3 forceSum = Vector3.zero;
		int contactPoint = 0;
		float minDistance = 1000000f;
		SphereCollider myCollider = this.collider as SphereCollider;
		for (int i = 1; i < velocityEstimators.Length-1; ++i) {
			//Vector3 positionDelta = transform.position - velocityEstimators[i].position;
            //float distance = positionDelta.magnitude;
			float distance = PointToSegmentDistance(	velocityEstimators[i-1].position,
														velocityEstimators[i+1].position,
														transform.position);
			
			if (distance < myCollider.radius) {
				if (distance < minDistance) {
					minDistance = distance;
					contactPoint = i;
				}
				Vector3 forceDirection = velocityEstimators[contactPoint+1].position - velocityEstimators[contactPoint-1].position;
				forceDirection = (new Vector3(-forceDirection.y, forceDirection.x, 0)).normalized;
				forceSum += forceDirection * (velocityEstimators[contactPoint].velocity.magnitude + 1) * velocityForceScalar;

			}
		}
		/*
		if (contactPoint > 0) {
			Vector3 forceDirection = velocityEstimators[contactPoint+1].position - velocityEstimators[contactPoint-1].position;
			forceDirection = (new Vector3(-forceDirection.y, forceDirection.x, 0)).normalized;
			forceSum = forceDirection * (velocityEstimators[contactPoint].velocity.magnitude + 1) * velocityForceScalar;
			Debug.Log("Contact point " + contactPoint.ToString() + " dir = " + forceDirection.ToString() + " vel = " + velocityEstimators[contactPoint].velocity.magnitude.ToString() + " forceSum = " + forceSum);
		}
		*/
		
		if (forceSum.sqrMagnitude > 1) {
			return forceSum.normalized;
		} else {
			return forceSum;
		}
	}
	
	private float PointToSegmentDistance(Vector3 vector1, Vector3 vector2, Vector3 point) {
  	// Return minimum distance between line segment vw and point p
  		float l2 = (vector1 - vector2).sqrMagnitude;
  		if (l2 == 0.0) return (point - vector1).magnitude;   // v == w case
  		float t = Vector3.Dot(point - vector1, vector2 - vector1) / l2;
  		if (t < 0.0) return (point - vector1).magnitude;      // Beyond the 'v' end of the segment
  		else if (t > 1.0) return (point - vector2).magnitude;   // Beyond the 'w' end of the segment
  		Vector3 projection = vector1 + t * (vector2 - vector1);  // Projection falls on the segment
  		return (point - projection).magnitude;
	}

}
