using UnityEngine;
using System.Collections;

public class BallBodyAnimation : MonoBehaviour {

    public Animation targetAnimation;
    public Transform[] runTransforms;
    public Transform[] handTransforms;

	// Use this for initialization
	void Start () {
        AnimationState runState = targetAnimation["walk"];
        foreach (Transform t in runTransforms)
        {
            runState.AddMixingTransform(t, true);
        }
        runState.speed = 3;
        runState.weight = 0.5f;
        
        AnimationState waveState = targetAnimation["WaveHandAnimation"];
        foreach (Transform t in handTransforms)
        {
            waveState.AddMixingTransform(t, true);
        }
        waveState.speed = 2;
        waveState.weight = 0.5f;
        targetAnimation.Play("WaveHandAnimation");
        targetAnimation.Blend("walk", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
