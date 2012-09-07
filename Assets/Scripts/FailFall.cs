using UnityEngine;
using System.Collections;

public class FailFall : MonoBehaviour {

    public FFTBallPhysics target;
    public float transformTime = 1f;
    public Vector3 targetEulerAngles;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        PerformAnimation();
    }

    public void PerformAnimation()
    {
        StartCoroutine(PerformAnimationCoroutine());
    }

    private IEnumerator PerformAnimationCoroutine()
    {
        target.enabled = false;
        target.rigidbody.isKinematic = true;
        float startTime = Time.time;
        Transform plane = target.transform.FindChild("Plane");
        Quaternion startRotation = plane.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
        while (Time.time < startTime + transformTime)
        {
            float factor = Mathf.InverseLerp(startTime, startTime + transformTime, Time.time);
            plane.rotation = Quaternion.Slerp(startRotation, targetRotation, factor);
            yield return new WaitForEndOfFrame();
        }
    }
}
