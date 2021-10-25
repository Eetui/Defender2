using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Runtime Set", menuName = "ScriptableObjects/Enemy Runtime Set")]
public class EnemyRuntimeSet : ScriptableObject
{
    private List<Enemy> _enemies = new List<Enemy>();

    public List<Enemy> Enemies => _enemies;

    public void Add(Enemy enemy)
    {
        if (!_enemies.Contains(enemy))
            _enemies.Add(enemy);
    }

    public void Remove(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }
}
