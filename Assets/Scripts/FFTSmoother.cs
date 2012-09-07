public class FFTSmoother
{
	internal float[] smoothedValues;

	public FFTSmoother (int fftSize)
	{
		smoothedValues = new float[fftSize];
	}
	
	public void process (float[] samples, float alphaValue) {
		for (int i = 2; i < smoothedValues.Length-3; i++) {
			smoothedValues[i] = alphaValue*smoothedValues[i];
			for (int j = 0; j < 5; ++j) {
				smoothedValues[i] += (1-alphaValue)*samples[i-2+j];
			}
		}
	}
}

