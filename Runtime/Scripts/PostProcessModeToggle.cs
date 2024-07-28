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

        public void OnChangeToggleValue()
        {
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
