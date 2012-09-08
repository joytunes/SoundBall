using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

    public AudioClip[] clips;
    private bool goingUp = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!!!!!!" + goingUp.ToString());

        if ((!audio.isPlaying) && goingUp)
        {
            Debug.Log("Woohoo!!!!!!");
            int clipInd = Random.Range(0, clips.Length);
            audio.clip = clips[clipInd];
            audio.Play();
            goingUp = false;
        }
        else
        {
            goingUp = true;
        }
    }
}
