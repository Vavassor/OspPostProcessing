using UdonSharp;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessMenu : UdonSharpBehaviour
    {
        public PostProcessSlider ambientOcclusionSlider;
        public PostProcessModeToggle ambientOcclusionModeToggle0;
        public PostProcessModeToggle ambientOcclusionModeToggle1;
        public PostProcessSlider bloomSlider;
        public PostProcessSlider chromaticAberrationSlider;
        public PostProcessModeToggle colorGradingModeToggle0;
        public PostProcessModeToggle colorGradingModeToggle1;
        public PostProcessSlider contrastSlider;
        public PostProcessSlider exposureSlider;
        public PostProcessToggle motionBlurToggle;
        public PostProcessSlider saturationSlider;
        public PostProcessSlider temperatureSlider;
        public PostProcessSlider tintSlider;
        public PostProcessSlider vignetteSlider;
    }
}
