using UnityEngine;

namespace TricksScripts
{
    public class Fetch : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoFetch()
        {
            if (stats.Love < 75)
            {
                Debug.Log("I don't know how to fetch yet. Please pet me more.");
                return;
            }

            Debug.Log("Here is a fish");
            stats.Sleepiness += 10;
        }
    }
}