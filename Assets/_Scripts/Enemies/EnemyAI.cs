using Arcade.Enemy.Health;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Rigidbody2D rigidbodyAI;
    private EnemyHealth health;
    private float desiredAngle;

    private void Awake()
    {
        rigidbodyAI = GetComponent<Rigidbody2D>();
        health = GetComponentInChildren<EnemyHealth>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health.SetHealth(5);
    }

    private void Update()
    {
        Vector3 desiredDirection = player.transform.position - transform.position;
        desiredAngle = Mathf.Atan2(desiredDirection.y, desiredDirection.x) * Mathf.Rad2Deg + 90;
        
    }
    private void FixedUpdate()
    {
        rigidbodyAI.transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        rigidbodyAI.velocity = Vector2.down * speed;
    }
}
