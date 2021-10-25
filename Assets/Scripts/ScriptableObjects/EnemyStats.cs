using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/Stats/Enemy Stats")]
public class EnemyStats : UnitStats
{
    [SerializeField] private float _damage;
    [SerializeField] private int _spawnInterval;
    public float Damage => _damage;
    public int SpawnInterval => _spawnInterval;
}
