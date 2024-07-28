using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessModeToggle : UdonSharpBehaviour
    {
        public AudioPlayer audioPlayer;
        public AudioClip enableSound;
        public PostProcessModeGroup modeGroup;
        public Toggle toggle;
        public int toggleId;

        private bool priorIsOn;

        public void OnChangeToggleValue()
        {
            // Don't play a sound if it's already toggled on.
            if (toggle.isOn == priorIsOn)
            {
                return;
            }

            priorIsOn = toggle.isOn;

            if (toggleId == 0)
            {
                modeGroup.OnChangeToggle0(this);
            }

            if (toggle.isOn)
            {
                audioPlayer.PlayClipAtPoint(enableSound, transform.position);
            }
        }

        public void ResetToggle()
        {
            modeGroup.ResetToDefault();
        }
    }
}
