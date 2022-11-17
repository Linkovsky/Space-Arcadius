using System.Collections;
using System.Collections.Generic;
using Arcade.Enemy.Health;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject projectile;
    
    private Rigidbody2D rigidbodyAI;
    private EnemyHealth health;
    private float desiredAngle;
    private float shootDelay = 2f;
    private bool canShootAgain = true;
    private bool firstShoot = true;
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
        if (canShootAgain)
            StartCoroutine(Shooting());
    }
    private void FixedUpdate()
    {
        rigidbodyAI.transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        rigidbodyAI.velocity = Vector2.down * speed;
    }

    private IEnumerator Shooting()
    {
        if (firstShoot)
        {
            firstShoot = false;
            canShootAgain = false;
            yield return new WaitForSeconds(2.5f);
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(shootDelay);
            canShootAgain = true;
        }
        else
        {
            canShootAgain = false;
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(shootDelay);
            canShootAgain = true;
        }
        
    }
}
