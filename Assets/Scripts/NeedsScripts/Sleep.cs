using UnityEngine;

namespace NeedsScripts
{
    public class Sleep : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoSleep()
        {
            if (stats.Sleepiness < 75)
            {
                Debug.Log("Not sleepy enough. I want to do stuff!");
                return;
            }
            stats.Sleepiness = 0;
            stats.Hunger = 75;
            stats.Thirst = 75;
        }
    }
}