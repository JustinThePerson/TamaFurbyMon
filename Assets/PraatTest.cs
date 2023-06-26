using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PraatTest : MonoBehaviour
{
    private KeywordRecognizer _keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("pet", Pet);
        actions.Add("feed", Feed);
        actions.Add("water", Water);
        actions.Add("sleep", Sleep);
        actions.Add("sit", Sit);
        actions.Add("roll over", RollOver);
        actions.Add("come here", ComeHere);
        actions.Add("fetch", Fetch);

        _keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        _keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Pet()
    {
        Debug.Log("I'm Being Pet");
    }
    private void Feed()
    {
        Debug.Log("I'm Fed");
    }private void Water()
    {
        Debug.Log("I'm Watered");
    }private void Sleep()
    {
        Debug.Log("I'm Sleeped");
    }private void Sit()
    {
        Debug.Log("I'm Sitting");
    }private void RollOver()
    {
        Debug.Log("I'm Rolled");
    }private void ComeHere()
    {
        Debug.Log("I'm Comming");
    }private void Fetch()
    {
        Debug.Log("I'm Fetched");
    }
}