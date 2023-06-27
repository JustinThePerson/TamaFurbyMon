using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PraatTest : MonoBehaviour
{
    [SerializeField]
    private SharkStats stats;
    
    private KeywordRecognizer _keywordRecognizer;
    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();

    void Start()
    {
        _actions.Add("pet", Pet);
        _actions.Add("eat", Feed);
        _actions.Add("water", Water);
        _actions.Add("sleep", Sleep);
        _actions.Add("sit", Sit);
        _actions.Add("roll over", RollOver);
        _actions.Add("come here", ComeHere);
        _actions.Add("fetch", Fetch);

        _keywordRecognizer = new KeywordRecognizer(_actions.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        _keywordRecognizer.Start();
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        _actions[speech.text].Invoke();
    }

    private void Pet()
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
    
    private void Feed()
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
    private void Water()
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
    private void Sleep()
    {
        if (stats.Sleepiness < 75)
        {
            Debug.Log("Not sleepy enough. I want to do stuff!");
            return;
        }
        stats.Sleepiness = 0;
        stats.Hunger = 75;
        stats.Thirst = 75;
    }
    private void Sit()
    {
        if (stats.Love <= 10) 
        {
            Debug.Log("I don't know how to sit yet. Please pet me more.");
            return;
        }
        
        Debug.Log("*Sits*");
        stats.Sleepiness += 10;
    }
    private void RollOver()
    {
        if (stats.Love <= 25)
        {
            Debug.Log("I don't know how to roll over yet. Please pet me more.");
            return;
        }
        
        Debug.Log("*Rolls*");
        stats.Sleepiness += 10;
    }
    private void ComeHere()
    {
        if (stats.Love < 50)
        {
            Debug.Log("I don't know how to come here yet. Please pet me more.");
            return;
        }

        Debug.Log("I'm coming");
        stats.Sleepiness += 10;
    }
    private void Fetch()
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