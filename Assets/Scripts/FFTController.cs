using UnityEngine;
using System.Collections;

public class FFTController : MonoBehaviour 
{
    public int numSamples = 128;
	public float minFreq = 300;
	public float maxFreq = 3400;
	public float alphaValue = 0.9f;
	public int smoothValue = 7;

    public GameObject spectrumBallTemplate;
    public bool useMicrophone = true;

	internal int fftSize;
    internal float[] spectrumSamples;
    internal float[] spectrumSamplesInRange;
	internal float[] ballPositions;
    private GameObject[] spectrumBalls;
	private FFTSmoother smoother;

	// Use this for initialization
	void Start () {
        Debug.Log("Devices : " + string.Join(",", Microphone.devices));
        if (useMicrophone)
        {
            audio.clip = Microphone.Start(null, true, 999, 44100);
        }
        
		audio.Play();
		float fftResolution = (maxFreq-minFreq)/numSamples;
		fftSize = 1 << ((int)(Mathf.Log(44100f / fftResolution) / Mathf.Log(2f)) + 1);
		Debug.Log ("FFT RES: " + fftResolution.ToString() + " Spectrum size: " + fftSize);
		spectrumSamples = new float[fftSize];
        spectrumSamplesInRange = new float[numSamples];
        spectrumBalls = new GameObject[numSamples];
		ballPositions = new float[numSamples];
		smoother = new FFTSmoother(numSamples);
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
		for (int i = 0; i < numSamples; ++i) {
			float freq = minFreq + (maxFreq-minFreq)*i/numSamples;
			int freqIndex = (int)(freq/44100f*fftSize);
			spectrumSamplesInRange[i] = spectrumSamples[ freqIndex ];
		}
		smoother.process(spectrumSamplesInRange, alphaValue, smoothValue);
		
		// Setting ball positions
		for (int i = 0; i < numSamples; i++)
        {
			ballPositions[i] = smoother.smoothedValues[i] + 0.03f;
            spectrumBalls[i].transform.localPosition = new Vector3(i, ballPositions[i], 0);
        }

        //if (Time.frameCount % 60 == 0)
        //{
        //    string[] floatStrings = System.Array.ConvertAll<float, System.String>(spectrumSamples, delegate (float input) { return input.ToString(); });
        //    Debug.Log(string.Join(",", floatStrings));
        //}
	}
}
