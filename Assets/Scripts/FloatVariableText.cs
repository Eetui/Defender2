using UnityEngine;
using TMPro;

public class FloatVariableText : MonoBehaviour
{
    [SerializeField] private TMP_Text uiTextObject;
    [SerializeField] private string text;
    [SerializeField] private FloatSO floatVariable;

    private void OnEnable()
    {
        floatVariable.OnValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        floatVariable.OnValueChanged -= UpdateText;
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextObject.text = text + floatVariable.Value;
    }
}
