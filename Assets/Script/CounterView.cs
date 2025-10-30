using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    private Text _text;

    private Counter _counter; 

    private void Awake()
    {
        _text = GetComponent<Text>();        
    }

    private void OnEnable()
    {
        _counter.OnUpdate += OnUpdateText;
    }

    private void OnDisable()
    {
        _counter.OnUpdate -= OnUpdateText;
    }

    public void Initialize(Counter counter)
    {
        _counter = counter;
    }

    public void OnUpdateText(string text)
    {
        _text.text = text;
    }    
}