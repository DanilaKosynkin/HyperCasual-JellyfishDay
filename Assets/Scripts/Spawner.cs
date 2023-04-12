using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private int _startPullSize = 10;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _startSpawnDelay;
    [SerializeField] private Restart _restart;

    private float _spawnDelay;
    private List<GameObject> _pullEnemy = new List<GameObject>();
    private float _currentTime;
    private int _previousSpawnPosition;
    private int _currentSpawnPosition;
    private DifficultyChanger _difficultyChanger;

    private void Start()
    {
        _difficultyChanger = DifficultyChanger.Instance;
        _spawnDelay = _startSpawnDelay;
        CreatePullObject();
        _restart.OnRestart += RestartEnemy;
        _difficultyChanger.OnDifficultyChanged += OnDifficultyChanged;
    }

    private void OnDestroy()
    {
        _difficultyChanger.OnDifficultyChanged -= OnDifficultyChanged;
        _restart.OnRestart -= RestartEnemy;
    }

    private void Update()
    {
        SpawnDelay();
    }

    private void CreatePullObject()
    {
        Transform parent = new GameObject().transform;
        parent.name = "PullObject " + _enemy.name;
        for (int i = 0; i <= _startPullSize; i++)
            _pullEnemy.Add(Instantiate(_enemy, transform.position, Quaternion.identity, parent));

        RestartEnemy();
    }

    private void RestartEnemy()
    {
        _currentTime = 0f;
        foreach (var enemy in _pullEnemy)
            enemy.SetActive(false);
    }

    private void SpawnEnemy()
    {
        foreach (var enemy in _pullEnemy)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                enemy.transform.position = new Vector3(_spawnPositions[_currentSpawnPosition].transform.position.x,
                    _spawnPositions[_currentSpawnPosition].transform.position.y, 0);
                return;
            }
        }
    }

    private void OnDifficultyChanged(float difficulty)
    {
        _spawnDelay = _startSpawnDelay / (difficulty * 0.03f + 1);
    }

    private void SpawnDelay()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnDelay)
        {
            _currentSpawnPosition = Random.Range(0, _spawnPositions.Length - 1);
            if (_currentSpawnPosition != _previousSpawnPosition)
            {
                _previousSpawnPosition = _currentSpawnPosition;
                SpawnEnemy();
                _currentTime = 0;
            }
        }
    }
}
