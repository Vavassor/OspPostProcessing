using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace OrchidSeal.PostProcessing
{
    /// <summary>
    /// A menu section that is only enabled on desktop.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class DesktopOnly : UdonSharpBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private Color enabledColor;
        [SerializeField]
        private Color iconEnabledColor;
        [SerializeField]
        private UnityEngine.UI.Image[] icons;
        [SerializeField]
        private UnityEngine.UI.Image[] images;
        [SerializeField]
        private TMPro.TMP_Text[] texts;

#if !UNITY_ANDROID
        void Start()
        {
            var localPlayer = Networking.LocalPlayer;

            if (Utilities.IsValid(localPlayer) && !localPlayer.IsUserInVR())
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;

                foreach (var icon in icons)
                {
                    icon.color = iconEnabledColor;
                }

                foreach (var image in images)
                {
                    image.color = enabledColor;
                }

                foreach (var text in texts)
                {
                    text.color = enabledColor;
                }
            }
        }
#endif
    }
}
