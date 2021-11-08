using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input;

    //general
    [SerializeField] private FloatSO _currentRound;
    [SerializeField] private EnemyRuntimeSet _runtimeSet;
    [SerializeField] private List<Enemy> _enemiesToSpawn = new List<Enemy>();

    private int[] _spawnAmount;
    private WaitForSecondsRealtime _waitForSecondsRealTime = new WaitForSecondsRealtime(0.5f);
    private CameraBounds _camBounds; //used for the spawn point

    private ObjectPooler _objectPool;

    //events
    [SerializeField] private StartOfRound startRound;
    [SerializeField] private EndOfRound endRound;

    private void Awake()
    {
        _spawnAmount = new int[_enemiesToSpawn.Count];
        _currentRound.SetValue(0);
        _camBounds = FindObjectOfType<CameraBounds>();
    }

    private void OnEnable()
    {
        _input.OnNextRoundEvent += StartRound;
    }

    private void Start()
    {
        _objectPool = ObjectPooler.Instance;

        foreach (var enemy in _enemiesToSpawn)
        {
            _objectPool.InitPool(enemy.gameObject, 10);
        }
    }

    private void OnDisable()
    {
        _input.OnNextRoundEvent -= StartRound;
    }

    public void StartRound()
    {
        StartCoroutine(SpawnRound());
    }

    private IEnumerator SpawnRound()
    {
        startRound.InvokeEvents();
        _currentRound.ApplyChange(1f); // Adding one to rounds

        //Setting how many eniems to spawn. Note that the list has to be in order.
        for (int i = 0; i < _enemiesToSpawn.Count; i++)
        {
            if (_currentRound.Value % _enemiesToSpawn[i].Stats.SpawnInterval == 0)
            {
                _spawnAmount[i]++;
            }
        }

        //Spawn enemies according to the spawn amount. Enemies will spawn in specific order.
        for (int i = 0; i < _enemiesToSpawn.Count; i++)
        {
            var amountToSpawn = _spawnAmount[i];
            while (amountToSpawn > 0)
            {
                var enemyToSpawn = _objectPool.GetObject(_enemiesToSpawn[i].gameObject);
                enemyToSpawn.transform.position = _camBounds.GetRandomPointOffScreen();
                enemyToSpawn.GetComponent<Enemy>().OnSpawn.Invoke();

                amountToSpawn--;
                yield return _waitForSecondsRealTime;
            }
        }

        StartCoroutine(CheckForRoundEnd());
    }

    private IEnumerator CheckForRoundEnd()
    {
        while (true)
        {
            if (_runtimeSet.Enemies.Count <= 0)
            {
                break;
            }

            yield return _waitForSecondsRealTime;
        }
        endRound.InvokeEvents();
    }
}
