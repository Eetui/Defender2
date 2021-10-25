using UnityEngine;
using UnityEngine.Events;

public class EndOfRound : MonoBehaviour
{
    [SerializeField] private InputActionsSO input = default;

    public UnityAction OnRoundEnd = delegate { };
    public UnityEvent OnRoundChangeEvent;

    [Range(10, 100)]
    [SerializeField] private int _baseReward = 25;
    [SerializeField] private FloatSO _playerMoney;
    [SerializeField] private FloatSO _roundPlayed;
    [SerializeField] private FloatSO _reward;

    public void InvokeEvents()
    {
        OnRoundChangeEvent.Invoke();
        OnRoundEnd.Invoke();
    }

    private void OnEnable()
    {
        OnRoundEnd += EndOfRoundReward;
        OnRoundEnd += EnableShortcutInput;
    }

    private void OnDisable()
    {
        OnRoundEnd -= EndOfRoundReward;
        OnRoundEnd -= EnableShortcutInput;
    }

    private void EndOfRoundReward()
    {
        _reward.SetValue(_baseReward * _roundPlayed.Value);
        _playerMoney.ApplyChange(_reward.Value);
    }

    private void EnableShortcutInput() => input.EnableShortcutInput();
}
