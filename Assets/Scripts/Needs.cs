using System.Collections;
using UnityEngine;

public class Needs : MonoBehaviour
{
    [SerializeField]
    private SharkStats stats;
    private void Start()
    {
        // Initialize statistics, HP, and timer
        stats.Hunger = 100;
        stats.Thirst = 100;
        stats.Sleepiness = 0;
        stats.Love = 0;
        stats.HealthPoints = 100;

        // Start the HP reduction coroutine
        StartCoroutine(ReduceHpOverTime());
    }

    private void Update()
    {
        // Check if the game is over
        if (stats.HealthPoints <= 0)
        {
            Debug.Log("user let the shark die");
            Application.Quit();
        }
    }

    private IEnumerator ReduceHpOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            // Check if the shark's statistics are below or above the threshold
            if (stats.Hunger > 50 || stats.Thirst > 50 || stats.Love < 50 || stats.Sleepiness > 100)
            {
                stats.HealthPoints--;
            }
            else if (stats.Hunger < 50 && stats.Thirst < 50 && stats.Love > 15 && stats.HealthPoints < 100)
            {
                stats.HealthPoints += 1;
            }
        }
    }
}
