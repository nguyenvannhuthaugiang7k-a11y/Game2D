using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _enemyCount = 5;
    [SerializeField]
    private Transform _spawnTopLeft, _spawnTopRight, _spawnBottotmLeft, _spawnBottomRight;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if(enemy != null){
            enemy.OnDie += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition(){

        Transform selectTransfrom = null;
        int randomValue = Random.Range(0, 4);
        SpawnPointType spawnType = (SpawnPointType)randomValue;
        switch (spawnType)
        {
            case SpawnPointType.TopLeft:
                {
                    selectTransfrom = _spawnTopLeft;
                    break;
                }
            case SpawnPointType.TopRight:
                {
                    selectTransfrom = _spawnTopRight;
                    break;
                }
            case SpawnPointType.BottomLeft:
                {
                    selectTransfrom = _spawnBottotmLeft;
                    break;
                }
            case SpawnPointType.BottomRight:
                {
                    selectTransfrom = _spawnBottomRight;
                    break;
                }
            default:
                {
                    selectTransfrom = _spawnTopLeft;
                    break;
                }
        }

        return selectTransfrom.position + (Vector3)Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum SpawnPointType
{
    TopLeft = 0,
    TopRight = 1,
    BottomLeft = 2,
    BottomRight = 3
}
