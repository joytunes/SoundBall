using UnityEngine;

public class FFTSmoother
{
	internal float[] smoothedValues;

	public FFTSmoother (int fftSize)
	{
		smoothedValues = new float[fftSize];
	}
	
	public void process (float[] samples, float alphaValue, int averageWindow) {
		for (int i = 0; i < smoothedValues.Length; i++) {
			smoothedValues[i] = alphaValue*smoothedValues[i];
			for (int j = Mathf.Max(0,i-averageWindow/2); j < Mathf.Min(samples.Length, i+averageWindow/2+1); ++j) {
				smoothedValues[i] += (1-alphaValue)*samples[j];
			}
		}
	}
}

