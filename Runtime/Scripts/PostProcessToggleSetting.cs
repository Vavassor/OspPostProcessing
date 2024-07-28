using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace OrchidSeal.PostProcessing
{
    /// <summary>
    /// Boolean setting shared across mutliple toggles.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessToggleSetting : UdonSharpBehaviour
    {
        public bool defaultIsOn;
        public PostProcessToggle[] toggles;

        [SerializeField]
        private PostProcessVolume postProcessVolume;

        public void OnChangeValue(PostProcessToggle toggle)
        {
            SetValue(toggle.toggle.isOn);
        }

        public void SetDefault(bool newIsOn)
        {
            defaultIsOn = newIsOn;
            SetValue(newIsOn);
        }

        private void SetValue(bool isOn, PostProcessToggle toggle = null)
        {
            postProcessVolume.weight = isOn ? 1.0f : 0.0f;

            foreach (var otherToggle in toggles)
            {
                if (otherToggle != toggle)
                {
                    otherToggle.toggle.SetIsOnWithoutNotify(isOn);
                }
            }
        }
    }
}
