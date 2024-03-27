using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private List<Transform> _spawnPoints;

    public EnemyAi enemyPrefabs;
    public PlayerController player;
    public List<Transform> patrolPoints;
    public int enemiesMaxCount = 5;
    public float delay = 5;
    public float increaseEnemiesCountDelay = 30;

    private float _timeLastSpawned;
    private List<EnemyAi> _enemies;

    
    private void Start()
    {
        _spawnPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAi>();

        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }
    private void IncreaseEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }

    private void Update()
    {
        CheckForDeadEnemies();



        CreateEnemy();
    }

    private void CheckForDeadEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
        
    }

    private void CreateEnemy()
    {
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;

        var enemy = Instantiate(enemyPrefabs);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
    
}
