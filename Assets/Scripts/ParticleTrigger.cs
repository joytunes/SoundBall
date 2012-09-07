using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour 
{
    public ParticleEmitter[] particleSystemTemplates;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Vector3 hitPosition = other.transform.position;
        foreach (ParticleEmitter particleSystemTemplate in particleSystemTemplates)
        {
            ParticleEmitter particleSystem = (ParticleEmitter)GameObject.Instantiate(
                particleSystemTemplate, hitPosition, Quaternion.identity);
            Debug.Log(particleSystem);
        }
        
        
    }
}
