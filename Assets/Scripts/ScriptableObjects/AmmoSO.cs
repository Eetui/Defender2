using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/BulletSO")]
public class AmmoSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name = "New Bullet";
    [SerializeField] private float _speed;
    public GameObject BaseBulletPrefab;

    [Header("Particles")]
    [SerializeField] private GameObject _particleEffecet;
    [SerializeField] private GameObject _shellParticleEffecet;

    public Sprite Sprite => _sprite;
    public string Name => _name;
    public float Speed => _speed;
    public GameObject ShellParticleEffecet => _shellParticleEffecet;
    public GameObject ParticleEffecet => _particleEffecet;
}