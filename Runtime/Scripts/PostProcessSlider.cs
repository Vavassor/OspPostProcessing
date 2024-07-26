using UdonSharp;
using UnityEngine.UI;

namespace OrchidSeal.PostProcessing
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessSlider : UdonSharpBehaviour
    {
        public PostProcessSetting setting;
        public Slider slider;

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
