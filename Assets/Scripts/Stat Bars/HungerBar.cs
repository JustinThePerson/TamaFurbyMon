using UnityEngine;
using UnityEngine.UI;

namespace Stat_Bars
{
    public class HungerBar : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;

        public Slider slider;

        private void Update()
        {
            while (true)
            {
                slider.value = stats.Hunger;
                return;
            }
        }
    }
}
