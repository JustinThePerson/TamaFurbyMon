using UnityEngine;

namespace TricksScripts
{
    public class RollOver : MonoBehaviour
    {
        [SerializeField]
        private SharkStats stats;
        
        public void GoRoll()
        {
            if (stats.Love <= 25)
            {
                Debug.Log("I don't know how to roll over yet. Please pet me more.");
                return;
            }
        
            Debug.Log("*Rolls*");
            stats.Sleepiness += 10;
        }
    }
}