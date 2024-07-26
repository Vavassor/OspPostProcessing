using UdonSharp;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessModeToggle : UdonSharpBehaviour
    {
        public PostProcessingModeGroup modeGroup;
        public Toggle toggle;
        public int toggleId;

        public void OnChangeToggleValue()
        {
            modeGroup.OnChangeToggle0(this);
        }

        public void ResetToggle()
        {
            modeGroup.ResetToDefault();
        }
    }
}
