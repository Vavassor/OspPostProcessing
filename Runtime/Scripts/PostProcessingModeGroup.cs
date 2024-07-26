using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessingModeGroup : UdonSharpBehaviour
    {
        public bool defaultIsOn;
        public PostProcessModeToggle[] toggles;

        [SerializeField]
        private PostProcessVolume[] postProcessVolumes;

        public void OnChangeToggle0(PostProcessModeToggle modeToggle)
        {
            var isOn = modeToggle.toggle.isOn;

            postProcessVolumes[0].enabled = isOn;
            postProcessVolumes[1].enabled = !isOn;

            foreach (var otherToggle in toggles)
            {
                if (otherToggle.toggleId == modeToggle.toggleId)
                {
                    if (!ReferenceEquals(otherToggle.gameObject, modeToggle.gameObject))
                    {
                        otherToggle.toggle.SetIsOnWithoutNotify(isOn);
                    }
                }
                else
                {
                    otherToggle.toggle.SetIsOnWithoutNotify(!isOn);
                }
            }
        }

        public void ResetToDefault()
        {
            postProcessVolumes[0].enabled = defaultIsOn;
            postProcessVolumes[1].enabled = !defaultIsOn;

            foreach (var otherToggle in toggles)
            {
                otherToggle.toggle.SetIsOnWithoutNotify(otherToggle.toggleId == 0 ? defaultIsOn : !defaultIsOn);
            }
        }

        public void SetDefault(bool newIsOn)
        {
            defaultIsOn = newIsOn;
            ResetToDefault();
        }
    }
}
