using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/BulletSO")]
public class AmmoSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name = "New Bullet";
    [SerializeField] private float _speed;

    public Sprite Sprite { get { return _sprite; } }
    public string Name { get { return _name; } }
    public float Speed { get { return _speed; } }

    public GameObject baseBulletPrefab;
}