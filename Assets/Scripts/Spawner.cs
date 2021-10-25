using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input;

    //general
    [SerializeField] private FloatSO currentRound;
    [SerializeField] private EnemyRuntimeSet runtimeSet;
    [SerializeField] private List<Enemy> enemiesToSpawn = new List<Enemy>();

    private int[] spawnAmount;
    private WaitForSecondsRealtime waitForSecondsRealTime = new WaitForSecondsRealtime(0.5f);
    private CameraBounds camBounds; //used for the spawn point

    //events
    [SerializeField] private StartOfRound startRound;
    [SerializeField] private EndOfRound endRound;

    private void Awake()
    {
        spawnAmount = new int[enemiesToSpawn.Count];
        currentRound.SetValue(0);
        camBounds = FindObjectOfType<CameraBounds>();
    }

    private void OnEnable()
    {
        _input.OnNextRoundEvent += StartRound;
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
        currentRound.ApplyChange(1f); // Adding one to rounds

        //Setting how many eniems to spawn. Note that the list has to be in order.
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            if (currentRound.Value % enemiesToSpawn[i].Stats.SpawnInterval == 0)
            {
                spawnAmount[i]++;
            }
        }

        //Spawn enemies according to the spawn amount. Enemies will spawn in specific order.
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            var amountToSpawn = spawnAmount[i];
            while (amountToSpawn > 0)
            {
                Instantiate(enemiesToSpawn[i].gameObject, camBounds.GetRandomPointOffScreen(), Quaternion.identity);
                amountToSpawn--;
                yield return waitForSecondsRealTime;
            }
        }

        StartCoroutine(CheckForRoundEnd());
    }

    private IEnumerator CheckForRoundEnd()
    {
        while (true)
        {
            if (runtimeSet.Enemies.Count <= 0)
            {
                break;
            }

            yield return waitForSecondsRealTime;
        }
        endRound.InvokeEvents();
    }
}
