using UdonSharp;
using UnityEngine;

namespace OrchidSeal.PostProcessing
{
    /// <summary>
    /// Shared settings for a group of post processing menus.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessVolumeGroup : UdonSharpBehaviour
    {
        public PostProcessMenu[] menus;
        public float uiSoundVolume = 0.25f;

        [Header("Defaults")]
        public float ambientOcclusion;
        public bool ambientOcclusionSao;
        public float bloom = 0.25f;
        public float chromaticAberration = 0.1f;
        public bool colorGradingAces = true;
        public float contrast;
        public float exposure;
        public bool motionBlur;
        public float saturation;
        public float temperature;
        public float tint;
        public float vignette;

        [Header("Settings")]
        public PostProcessSetting ambientOcclusionSetting;
        public PostProcessModeGroup ambientOcclusionModeGroup;
        public PostProcessSetting bloomSetting;
        public PostProcessSetting chromaticAberrationSetting;
        public PostProcessModeGroup colorGradingModeGroup;
        public PostProcessSetting contrastSetting;
        public PostProcessSetting exposureSetting;
        public PostProcessToggleSetting motionBlurSetting;
        public PostProcessSetting saturationSetting;
        public PostProcessSetting temperatureSetting;
        public PostProcessSetting tintSetting;
        public PostProcessSetting vignetteSetting;

        private void Start()
        {
            ambientOcclusionSetting.sliders = new PostProcessSlider[menus.Length];
            ambientOcclusionModeGroup.toggles = new PostProcessModeToggle[2 * menus.Length];
            bloomSetting.sliders = new PostProcessSlider[menus.Length];
            chromaticAberrationSetting.sliders = new PostProcessSlider[menus.Length];
            colorGradingModeGroup.toggles = new PostProcessModeToggle[2 * menus.Length];
            contrastSetting.sliders = new PostProcessSlider[menus.Length];
            exposureSetting.sliders = new PostProcessSlider[menus.Length];
            motionBlurSetting.toggles = new PostProcessToggle[menus.Length];
            saturationSetting.sliders = new PostProcessSlider[menus.Length];
            temperatureSetting.sliders = new PostProcessSlider[menus.Length];
            tintSetting.sliders = new PostProcessSlider[menus.Length];
            vignetteSetting.sliders = new PostProcessSlider[menus.Length];

            for (var i = 0; i < menus.Length; i++)
            {
                SetUpSlider(ambientOcclusionSetting, menus[i].ambientOcclusionSlider, i);
                SetUpModeToggle(ambientOcclusionModeGroup, menus[i].ambientOcclusionModeToggle0, 2 * i);
                SetUpModeToggle(ambientOcclusionModeGroup, menus[i].ambientOcclusionModeToggle1, 2 * i + 1);
                SetUpSlider(bloomSetting, menus[i].bloomSlider, i);
                SetUpSlider(chromaticAberrationSetting, menus[i].chromaticAberrationSlider, i);
                SetUpModeToggle(colorGradingModeGroup, menus[i].colorGradingModeToggle0, 2 * i);
                SetUpModeToggle(colorGradingModeGroup, menus[i].colorGradingModeToggle1, 2 * i + 1);
                SetUpSlider(contrastSetting, menus[i].contrastSlider, i);
                SetUpSlider(exposureSetting, menus[i].exposureSlider, i);
                SetUpToggle(motionBlurSetting, menus[i].motionBlurToggle, i);
                SetUpSlider(saturationSetting, menus[i].saturationSlider, i);
                SetUpSlider(temperatureSetting, menus[i].temperatureSlider, i);
                SetUpSlider(tintSetting, menus[i].tintSlider, i);
                SetUpSlider(vignetteSetting, menus[i].vignetteSlider, i);
                menus[i].audioPlayer.volumeGroup = this;
            }

            ambientOcclusionSetting.SetDefault(ambientOcclusion);
            ambientOcclusionModeGroup.SetDefault(ambientOcclusionSao);
            bloomSetting.SetDefault(bloom);
            chromaticAberrationSetting.SetDefault(chromaticAberration);
            colorGradingModeGroup.SetDefault(colorGradingAces);
            contrastSetting.SetDefault(contrast);
            exposureSetting.SetDefault(exposure);
            motionBlurSetting.SetDefault(motionBlur);
            saturationSetting.SetDefault(saturation);
            temperatureSetting.SetDefault(temperature);
            tintSetting.SetDefault(tint);
            vignetteSetting.SetDefault(vignette);
        }

        private static void SetUpModeToggle(PostProcessModeGroup modeGroup, PostProcessModeToggle toggle, int toggleIndex)
        {
            modeGroup.toggles[toggleIndex] = toggle;
            toggle.modeGroup = modeGroup;
        }

        private static void SetUpSlider(PostProcessSetting setting, PostProcessSlider slider, int sliderIndex)
        {
            setting.sliders[sliderIndex] = slider;
            slider.setting = setting;
        }

        private static void SetUpToggle(PostProcessToggleSetting setting, PostProcessToggle toggle, int toggleIndex)
        {
            setting.toggles[toggleIndex] = toggle;
            toggle.setting = setting;
        }
    }
}
