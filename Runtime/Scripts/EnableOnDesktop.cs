using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class EnableOnDesktop : UdonSharpBehaviour
    {
        public GameObject[] objectsToEnable;

#if !UNITY_ANDROID
        void Start()
        {
            var localPlayer = Networking.LocalPlayer;

            if (Utilities.IsValid(localPlayer) && !localPlayer.IsUserInVR())
            {
                foreach (var obj in objectsToEnable)
                {
                    obj.SetActive(true);
                }
            }
        }
#endif
    }
}
