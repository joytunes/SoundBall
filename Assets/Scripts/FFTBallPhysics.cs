using UnityEngine;
using System.Collections;

public class FFTBallPhysics : MonoBehaviour {

    public FFTController controller;
    public float velocityForceScalar = 1;

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
            rigidbody.AddForce(overallForce, ForceMode.Force);
        }
	}

    private Vector3 CalculateOverallForce()
    {
        SphereCollider myCollider = this.collider as SphereCollider;
        Vector3 forceSum = Vector3.zero;
        foreach (VelocityEstimator estimator in velocityEstimators)
        {
            Vector3 positionDelta = transform.position - estimator.transform.position;
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
}
