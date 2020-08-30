using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // enemy colored game objects
    [SerializeField]
    private GameObject enemyDefeated;
    [SerializeField]
    private List<GameObject> enemyColors = new List<GameObject>(4);

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

    private void GenerateRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyColors.Count);

        Instantiate(
            enemyColors[0],
            enemySpawnPoint - Vector3.right,
            transform.rotation
        );
    }

    public void SetDefeatSprite(GameObject currentEnemy)
    {
        if (enemyDefeated)
        {
        //TODO: not working, enemy changing sprite
            // gets current position to spawn defeated enemy
            Vector3 currentPosition = currentEnemy.transform.position;

            Destroy(currentEnemy); // destroy current colored

            // creates blue one
            Instantiate(
                enemyDefeated,
                currentPosition,
                transform.rotation
            );
        }
    }

    public static EnemyManager Instance { get; private set; }
}
