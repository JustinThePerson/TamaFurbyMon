using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    public int timer;
    void Update()
    {
        display.SetText("Timer:{0}", timer);
    }

    private void Start()
    { 
        StartCoroutine(TimeGoesUpMuchWow());
    }

    private IEnumerator TimeGoesUpMuchWow()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
        }
    }
}
