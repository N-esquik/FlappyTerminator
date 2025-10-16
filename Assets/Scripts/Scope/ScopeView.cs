using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScopeCounter))]
public class ScopeView : MonoBehaviour
{
    private ScopeCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<ScopeCounter>();
    }

    private void OnEnable()
    {
        _counter.ValueChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(TextMeshProUGUI ScopeText, int Scope)
    {
        if (ScopeText != null)
        {
            ScopeText.text = $"Очки: {Scope}";
        }
    }
}
