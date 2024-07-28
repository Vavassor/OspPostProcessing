using UdonSharp;
using UnityEngine;

namespace OrchidSeal.PostProcessing
{
    /// <summary>
    /// Audio player for a menu.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class AudioPlayer : UdonSharpBehaviour
    {
        public PostProcessVolumeGroup volumeGroup;

        public void PlayClipAtPoint(AudioClip clip, Vector3 position)
        {
            if (volumeGroup.uiSoundVolume > 0.0f)
            {
                AudioSource.PlayClipAtPoint(clip, position, volumeGroup.uiSoundVolume);
            }
        }
    }
}
