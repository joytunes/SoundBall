using UnityEngine;
using System.Collections;

public class FFTController : MonoBehaviour 
{

    private float[] spectrumSamples;
	// Use this for initialization
	void Start () {
        Debug.Log("Devices : " + string.Join(",", Microphone.devices));
        audio.clip = Microphone.Start(null, true, 100, 44100);
        spectrumSamples = new float[128];
	}
	

	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 60 == 0)
        {
            audio.GetSpectrumData(spectrumSamples, 0, FFTWindow.Rectangular);
            string[] floatStrings = System.Array.ConvertAll<float, System.String>(spectrumSamples, delegate (float input) { return input.ToString(); });
            Debug.Log(string.Join(",", floatStrings));
        }
	}
}
