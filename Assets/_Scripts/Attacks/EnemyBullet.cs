using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody2D;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = -transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            
        }
            
    }
}
