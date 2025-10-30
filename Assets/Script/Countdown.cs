using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private const float Delay = 0.5f;

    private Counter _counter;

    private InputHandler _inputHandler;    

    private bool _isRun = true;

    private void Awake()
    {
        _counter = new Counter();
        _inputHandler = GetComponent<InputHandler>();
        CounterView counterView = GetComponent<CounterView>();
        counterView.Initialize(_counter); 
    }

    private void OnEnable()
    {
        _inputHandler.OnClick += ChangeStateCounter;        
    }

    private void OnDisable()
    {        
        _inputHandler.OnClick -= ChangeStateCounter;
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
}
