public class FFTSmoother
{
	internal float[] smoothedValues;

	public FFTSmoother (int fftSize)
	{
		smoothedValues = new float[fftSize];
	}
	
	public void process (float[] samples, float alphaValue) {
		for (int i = 0; i < smoothedValues.Length; i++) {
			smoothedValues[i] = alphaValue*smoothedValues[i] + (1-alphaValue)*samples[i];
		}
	}
}

