using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessToggle : UdonSharpBehaviour
    {
        public AudioPlayer audioPlayer;
        public AudioClip disableSound;
        public AudioClip enableSound;
        public PostProcessToggleSetting setting;
        public Toggle toggle;

        public void OnChangeValue()
        {
            setting.OnChangeValue(this);
            audioPlayer.PlayClipAtPoint(toggle.isOn ? enableSound : disableSound, transform.position);
        }

        public void ResetToggle()
        {
            toggle.SetIsOnWithoutNotify(setting.defaultIsOn);
            setting.OnChangeValue(this);
        }
    }
}
