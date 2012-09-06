using UnityEngine;
using System.Collections;

public class FFTController : MonoBehaviour 
{
    public int numSamples = 128;
	public float alphaValue = 0.8f;
    public GameObject spectrumBallTemplate;

    internal float[] spectrumSamples;
	internal float[] ballPositions;
    private GameObject[] spectrumBalls;

	// Use this for initialization
	void Start () {
        Debug.Log("Devices : " + string.Join(",", Microphone.devices));
        //audio.clip = Microphone.Start(null, true, 999, 44100);
		audio.Play();
        spectrumSamples = new float[numSamples*4];
        spectrumBalls = new GameObject[numSamples];
		ballPositions = new float[numSamples];
        for (int i = 0; i < numSamples; i++)
        {
            spectrumBalls[i] = (GameObject)GameObject.Instantiate(spectrumBallTemplate);
            spectrumBalls[i].transform.parent = this.transform;
            spectrumBalls[i].transform.localPosition = new Vector3(i, 0, 0);
        }
	}

    // Update is called once per frame
    void Update()
    {
        audio.GetSpectrumData(spectrumSamples, 0, FFTWindow.Hamming);
		
		// Smoothing values
        for (int i = 0; i < numSamples; i++)
        {
            ballPositions[i] = alphaValue*ballPositions[i] + (1-alphaValue)*spectrumSamples[i];
        }
		
		// Setting ball positions
		for (int i = 0; i < numSamples; i++)
        {
            spectrumBalls[i].transform.localPosition = new Vector3(i, ballPositions[i], 0);
        }

        //if (Time.frameCount % 60 == 0)
        //{
        //    string[] floatStrings = System.Array.ConvertAll<float, System.String>(spectrumSamples, delegate (float input) { return input.ToString(); });
        //    Debug.Log(string.Join(",", floatStrings));
        //}
	}
}
