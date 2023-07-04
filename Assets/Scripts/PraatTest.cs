using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PraatTest : MonoBehaviour
{
    [SerializeField]
    private SharkStats stats;

    [SerializeField]
    private Animator animator;

    private KeywordRecognizer _keywordRecognizer;
    private HashSet<string> _actions;
    private static readonly int Rolls = Animator.StringToHash("Rolls");

    private void Start()
    {
        _actions = new HashSet<string>(GetActions());
        _keywordRecognizer = new KeywordRecognizer(_actions.ToArray());
        _keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        _keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        HandleAction(speech.text);
    }

    private void HandleAction(string action)
    {
        if (!_actions.Contains(action))
        {
            Debug.Log("Unknown action: " + action);
            return;
        }

        switch (action)
        {
            case "pet":
            case "love":
                Pet();
                break;
            case "eat":
            case "food":
            case "feed":
                Feed();
                break;
            case "drink":
            case "water":
                Drink();
                break;
            case "sleep":
            case "rest":
                Sleep();
                break;
            case "sit":
                Sit();
                break;
            case "roll over":
            case "roll":
                RollOver();
                break;
            case "come here":
                ComeHere();
                break;
            case "fetch":
                Fetch();
                break;
            case "Quit":
                Quit();
                break;
        }
    }

    private void Pet()
    {
        if (stats.Love == 100)
        {
            return;
        }

        UpdateStats(10, 0, 0, 5);
    }

    private void Feed()
    {
        if (stats.Hunger == 0)
        {
            return;
        }

        UpdateStats(0, -25, 0, 0);
    }

    private void Drink()
    {
        if (stats.Thirst == 0)
        {
            return;
        }

        UpdateStats(0, 0, -25, 0);
    }

    private void Sleep()
    {
        if (stats.Sleepiness < 75)
        {
            return;
        }

        UpdateStats(0, 75, 75, -stats.Sleepiness);
    }

    private void Sit()
    {
        if (stats.Love <= 10)
        {
            Debug.Log("I don't know how to sit yet. Please pet me more.");
            return;
        }

        Debug.Log("*Sits*");
        UpdateStats(0, 0, 0, 10);
    }

    private void RollOver()
    {
        /*if (stats.Love <= 25)
        {
            Debug.Log("I don't know how to roll over yet. Please pet me more.");
            return;
        }*/
        
        animator.SetTrigger(Rolls);
        Debug.Log("*Rolls*");
        UpdateStats(0, 0, 0, 10);
    }

    private void ComeHere()
    {
        if (stats.Love < 50)
        {
            Debug.Log("I don't know how to come here yet. Please pet me more.");
            return;
        }

        Debug.Log("I'm coming");
        UpdateStats(0, 0, 0, 10);
    }

    private void Fetch()
    {
        if (stats.Love < 75)
        {
            Debug.Log("I don't know how to fetch yet. Please pet me more.");
            return;
        }

        Debug.Log("Here is a fish");
        UpdateStats(0, 0, 0, 10);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void UpdateStats(int loveDelta, int hungerDelta, int thirstDelta, int sleepinessDelta)
    {
        stats.Love += loveDelta;
        stats.Hunger += hungerDelta;
        stats.Thirst += thirstDelta;
        stats.Sleepiness += sleepinessDelta;
    }

    private IEnumerable<string> GetActions()
    {
        yield return "pet";
        yield return "love";
        yield return "eat";
        yield return "food";
        yield return "drink";
        yield return "water";
        yield return "sleep";
        yield return "rest";
        yield return "sit";
        yield return "roll over";
        yield return "come here";
        yield return "fetch";
        yield return "Quit";
    }
}
