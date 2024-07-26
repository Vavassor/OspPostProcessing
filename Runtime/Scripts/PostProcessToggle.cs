using UdonSharp;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessToggle : UdonSharpBehaviour
    {
        public Toggle toggle;
        public PostProcessToggleSetting setting;

        public void OnChangeValue()
        {
            setting.OnChangeValue(this);
        }

        public void ResetToggle()
        {
            toggle.isOn = setting.defaultIsOn;
        }
    }
}
