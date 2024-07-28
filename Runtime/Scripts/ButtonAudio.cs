using UdonSharp;
using UnityEngine;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ButtonAudio : UdonSharpBehaviour
    {
        public AudioClip activateSound;
        public AudioPlayer audioPlayer;

        public void OnClickButton()
        {
            audioPlayer.PlayClipAtPoint(activateSound, transform.position);
        }
    }
}
