using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private const float Delay = 0.5f;

    private Counter _counter;

    private InputHandler _inputHandler;
    private CounterView _counterView;

    private bool _isRun = true;

    public void Awake()
    {
        _counter = new Counter();
        _inputHandler = GetComponent<InputHandler>();
        _counterView = GetComponent<CounterView>();
    }

    public void ChangeStateCounter()
    {        
        _isRun = !_isRun;

        if (_isRun)
        {
            StartCoroutine(Count());
        }
        else
        {
            StopCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        while (_isRun)
        {
            _counter.RaiseValue();            
            yield return wait;
        }
    }

    private void OnEnable()
    {
        _inputHandler.OnClick += ChangeStateCounter;
        _counter.OnUpdate += _counterView.UpdateText; 
    }

    private void OnDisable()
    {
        _counter.OnUpdate -= _counterView.UpdateText;
        _inputHandler.OnClick -= ChangeStateCounter;
    }
}
