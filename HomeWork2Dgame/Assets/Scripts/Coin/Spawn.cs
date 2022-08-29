using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] private int _numberCoins;
    [SerializeField] private float _delay;

    private Coroutine _spawnCoin;
    private int _minNumberRandom = 0;

    void Start()
    {
        _spawnCoin = StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _numberCoins; i++)
        {
            yield return waitForSeconds;
            int randomPoinGeneration = Random.Range(_minNumberRandom, _pointsSpawn.Length);
            Instantiate(_coin, _pointsSpawn[randomPoinGeneration]);
        }
    }
}
