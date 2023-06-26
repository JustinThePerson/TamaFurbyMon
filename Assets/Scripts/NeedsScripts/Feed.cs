using UnityEngine;

namespace NeedsScripts
{
    public class Feed : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoFeed()
        {
            if (stats.Sleepiness > 75)
            {
                Debug.Log("Maybe i should sleep.");
            }
            if(stats.Hunger == 0)
            {
                Debug.Log("I'm full");
            
                return;
            }
            stats.Sleepiness += 5;
            stats.Hunger -= 25;
        }
    }
}