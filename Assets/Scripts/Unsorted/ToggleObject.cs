using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] private GameObject _togglableObject;

    public void Toggle() => _togglableObject.SetActive(!_togglableObject.activeInHierarchy);
    public void Toggle(GameObject toggleObject) => toggleObject.SetActive(!toggleObject.activeInHierarchy);
}
