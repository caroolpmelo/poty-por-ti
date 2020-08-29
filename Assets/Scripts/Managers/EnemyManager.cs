using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // enemy colored game objects
    [SerializeField]
    private List<GameObject> enemyColors = new List<GameObject>(5);

    private Vector3 enemySpawnPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // generate enemy out of screen bounds
        enemySpawnPoint = new Vector3(9.0f, transform.position.y);

        //InvokeRepeating("GenerateRandomEnemy", 2.0f, 3.0f);
        GenerateRandomEnemy();
    }

    private void Update()
    {
        //GenerateRandomEnemy();
    }

    private void GenerateRandomEnemy()
    {
        int randomIndex = Random.Range(0, 5);

        Instantiate(
            enemyColors[randomIndex],
            enemySpawnPoint - Vector3.right,
            transform.rotation
        );
    }

    public static EnemyManager Instance { get; private set; }
}
