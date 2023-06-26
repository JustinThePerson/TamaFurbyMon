using UnityEngine;

namespace NeedsScripts
{
    public class Pet : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoPet()
        {
            if (stats.Sleepiness > 75)
            {
                Debug.Log("Maybe i should sleep.");
            }
            if(stats.Love == 100)
            {
                Debug.Log("Okay that's enough");
            
                return;
            }
            stats.Sleepiness += 5;
            stats.Love += 5;
        }
    }
}