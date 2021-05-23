using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;

    public GameObject Meteor;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
            Debug.Log(_points[i].transform.position);
        }

        StartCoroutine(CreateMeteors());
    }

    private IEnumerator CreateMeteors()
    {
        Debug.Log("3");
        var waitTwoSeconds = new WaitForSeconds(2f);
        while (true)
        {
            Vector3 pointPosition = _points[Random.Range(0, _spawnPoints.childCount)].transform.position;
            Instantiate(Meteor, pointPosition, Quaternion.identity);

            yield return waitTwoSeconds;
        }

    }
}
