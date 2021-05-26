using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _meteor;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoint.childCount];
        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }

        StartCoroutine(CreateMeteors());
    }

    private IEnumerator CreateMeteors()
    {
        float timeBetweenSpawn = 2f;
        var waitTwoSeconds = new WaitForSeconds(timeBetweenSpawn);
        while (true)
        {
            Vector3 pointPosition = _points[Random.Range(0, _spawnPoint.childCount)].transform.position;
            Instantiate(_meteor, pointPosition, Quaternion.identity);

            yield return waitTwoSeconds;
        }

    }
}