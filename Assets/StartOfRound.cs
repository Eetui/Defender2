using UnityEngine;
using UnityEngine.Events;

public class StartOfRound : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input = default;

    public UnityAction OnRoundStart = delegate { };
    public UnityEvent OnRoundChangeEvent;

    public void InvokeEvents()
    {
        OnRoundChangeEvent.Invoke();
        OnRoundStart.Invoke();
    }

    private void OnEnable()
    {
        OnRoundStart += DisableShortcutInput;
    }

    private void OnDisable()
    {
        OnRoundStart -= DisableShortcutInput;
    }

    private void DisableShortcutInput() => _input.DisableShortcutInput();
}
