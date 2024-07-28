using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessSlider : UdonSharpBehaviour
    {
        public AudioPlayer audioPlayer;
        public AudioClip resetSound;
        public PostProcessSetting setting;
        public Slider slider;

        public void OnClickReset()
        {
            slider.value = setting.defaultValue;
            audioPlayer.PlayClipAtPoint(resetSound, transform.position);
        }

        public void OnChangeValue()
        {
            setting.OnChangeValue(this);
        }

        public void ResetSlider()
        {
            slider.value = setting.defaultValue;
        }
    }
}
