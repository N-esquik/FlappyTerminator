using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
public class EnemyGenerator : MonoBehaviour
{
    private EnemyPool _enemyPool;
    
    private float _delay = 10;
    private float _lowerBound = -20;
    private float _upperBound = 15;

    private void Awake()
    {
        _enemyPool = GetComponent<EnemyPool>();
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    public void ResetEnemy()
    {
        _enemyPool.Reset();
    }

    public void ResetPool(Enemy enemy)
    {
        _enemyPool.ReturnObjectPool(enemy);
    }


    private IEnumerator GenerateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_upperBound, _lowerBound);

        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = _enemyPool.GetObject();
        enemy.transform.position = spawnPoint;
        
        enemy.gameObject.SetActive(true);
    }
}
