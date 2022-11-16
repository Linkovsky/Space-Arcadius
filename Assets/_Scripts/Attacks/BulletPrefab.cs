using Arcade.Enemy.Health;
using UnityEngine;

namespace Arcade.PlayerSpaceShip.Fire
{
    public class BulletPrefab : MonoBehaviour
    {
        [SerializeField] private Projectile bullet;

        private Rigidbody2D rb;
        private Vector2 topCameraBounds;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            topCameraBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        }

        private void Update()
        {
            if(transform.position.y > topCameraBounds.y)
                Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            rb.velocity = Vector2.up * bullet.FlyDistance;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponentInChildren<EnemyHealth>().TakeDamage(bullet.Damage);
                Destroy(this.gameObject);
            }
        }
    }
}
