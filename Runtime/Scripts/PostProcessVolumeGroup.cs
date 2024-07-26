using UdonSharp;
using UnityEngine;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessVolumeGroup : UdonSharpBehaviour
    {
        [Header("Menus")]
        public PostProcessMenu[] menus;

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
        public PostProcessingModeGroup ambientOcclusionModeGroup;
        public PostProcessSetting bloomSetting;
        public PostProcessSetting chromaticAberrationSetting;
        public PostProcessingModeGroup colorGradingModeGroup;
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
                ambientOcclusionSetting.sliders[i] = menus[i].ambientOcclusionSlider;
                menus[i].ambientOcclusionSlider.setting = ambientOcclusionSetting;

                ambientOcclusionModeGroup.toggles[2 * i] = menus[i].ambientOcclusionModeToggle0;
                menus[i].ambientOcclusionModeToggle0.modeGroup = ambientOcclusionModeGroup;
                ambientOcclusionModeGroup.toggles[2 * i + 1] = menus[i].ambientOcclusionModeToggle1;
                menus[i].ambientOcclusionModeToggle1.modeGroup = ambientOcclusionModeGroup;

                bloomSetting.sliders[i] = menus[i].bloomSlider;
                menus[i].bloomSlider.setting = bloomSetting;

                chromaticAberrationSetting.sliders[i] = menus[i].chromaticAberrationSlider;
                menus[i].chromaticAberrationSlider.setting = chromaticAberrationSetting;

                colorGradingModeGroup.toggles[2 * i] = menus[i].colorGradingModeToggle0;
                menus[i].colorGradingModeToggle0.modeGroup = colorGradingModeGroup;
                colorGradingModeGroup.toggles[2 * i + 1] = menus[i].colorGradingModeToggle1;
                menus[i].colorGradingModeToggle1.modeGroup = colorGradingModeGroup;

                contrastSetting.sliders[i] = menus[i].contrastSlider;
                menus[i].contrastSlider.setting = contrastSetting;

                exposureSetting.sliders[i] = menus[i].exposureSlider;
                menus[i].exposureSlider.setting = exposureSetting;

                motionBlurSetting.toggles[i] = menus[i].motionBlurToggle;
                menus[i].motionBlurToggle.setting = motionBlurSetting;

                saturationSetting.sliders[i] = menus[i].saturationSlider;
                menus[i].saturationSlider.setting = saturationSetting;

                temperatureSetting.sliders[i] = menus[i].temperatureSlider;
                menus[i].temperatureSlider.setting = temperatureSetting;

                tintSetting.sliders[i] = menus[i].tintSlider;
                menus[i].tintSlider.setting = tintSetting;

                vignetteSetting.sliders[i] = menus[i].vignetteSlider;
                menus[i].vignetteSlider.setting = vignetteSetting;
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
    }
}
