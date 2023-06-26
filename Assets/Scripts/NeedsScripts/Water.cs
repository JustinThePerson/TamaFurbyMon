using UnityEngine;

namespace NeedsScripts
{
    public class Water : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoWater()
        {
            if (stats.Sleepiness > 75)
            {
                Debug.Log("Maybe i should sleep.");
            }
            if(stats.Thirst == 0)
            {
                Debug.Log("I'm full");
            
                return;
            }
            stats.Sleepiness += 5;
            stats.Thirst -= 25;
        }
    }
}