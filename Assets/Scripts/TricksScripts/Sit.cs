using UnityEngine;

namespace TricksScripts
{
    public class Sit : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;

        public void GoSit()
        {
            if (stats.Love <= 10) 
            {
                Debug.Log("I don't know how to sit yet. Please pet me more.");
                return;
            }
        
            Debug.Log("*Sits*");
            stats.Sleepiness += 10;
        }
    }
} 