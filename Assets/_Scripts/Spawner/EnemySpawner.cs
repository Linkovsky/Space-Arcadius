using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Vector2> enemies = new List<Vector2>();
    [SerializeField] private Transform enemyPrefab;

    private static EnemySpawner instance;
    private BoxCollider2D boxCollider;
    public EnemySpawner Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            enemies.Add(GetNewPosition());
            Instantiate(enemyPrefab, enemies[i], Quaternion.identity);
        }
    }

    private Vector2 GetNewPosition() => new(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y));
}
