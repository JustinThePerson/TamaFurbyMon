using UnityEngine;

namespace TricksScripts
{
    public class ComeHere : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoComeHere()
        {
            if (stats.Love < 50)
            {
                Debug.Log("I don't know how to come here yet. Please pet me more.");
                return;
            }

            Debug.Log("I'm coming");
            stats.Sleepiness += 10;
        }
    }
}