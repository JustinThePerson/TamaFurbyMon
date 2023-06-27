using UnityEngine;
using UnityEngine.UI;

namespace Stat_Bars
{
    public class SleepyBar : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;

        public Slider slider;

        private void Update()
        {
            while (true)
            {
                slider.value = stats.Sleepiness;
                return;
            }
        }
    }
}
