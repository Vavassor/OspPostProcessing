using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessSetting : UdonSharpBehaviour
    {
        public float defaultValue;
        public PostProcessSlider[] sliders;
        public bool useTwoWayMode = true;

        [SerializeField]
        private PostProcessVolume[] postProcessVolumes;

        public void OnChangeValue(PostProcessSlider slider)
        {
            SetValue(slider.slider.value);
        }

        public void SetDefault(float newValue)
        {
            defaultValue = newValue;
            SetValue(newValue);
        }

        private void SetValue(float value, PostProcessSlider slider = null)
        {
            if (postProcessVolumes.Length > 1 && useTwoWayMode)
            {
                if (value <= 0)
                {
                    postProcessVolumes[0].weight = Mathf.Abs(value);
                    postProcessVolumes[1].weight = 0;
                }
                else
                {
                    postProcessVolumes[0].weight = 0;
                    postProcessVolumes[1].weight = value;
                }
            }
            else
            {
                foreach (var volume in postProcessVolumes)
                {
                    volume.weight = value;
                }
            }

            foreach (var otherSlider in sliders)
            {
                if (otherSlider != slider)
                {
                    otherSlider.slider.SetValueWithoutNotify(value);
                }
            }
        }
    }
}
