using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour, IPointerClickHandler
{
    private const float Delay = 0.5f;

    private Text _text; 

    private Counter _counter;

    private bool _isRun = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
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
    }

    private void Awake()
    {
        _counter = new Counter();
        _text = GetComponent<Text>();

        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        while (_isRun)
        {
            _counter.RaiseValue();
            _text.text = _counter.ToString();
            yield return wait;
        }
    }
}
