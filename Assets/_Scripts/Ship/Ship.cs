using Arcade.PlayerSpaceShip.Fire;
using Arcade.PlayerSpaceShip.Ship.Movement;
using System.Collections;
using UnityEngine;

namespace Arcade.PlayerSpaceShip.Ship
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private InputControlls inputControlls;
        [SerializeField] private Transform prefabTransform;
        [SerializeField] private Projectile bulletPrefab;

        private WaitForSeconds attackDelay;
        private Rigidbody2D rb;

        private bool shootingDelay;
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            attackDelay = new WaitForSeconds(.10f);
        }
        // Update is called once per frame
        void Update()
        {
            inputControlls.CheckForInputs();
            if (Input.GetKey("space"))
                if (!shootingDelay)
                {
                    shootingDelay = true;
                    StartCoroutine(AttackDelay());
                    Instantiate(bulletPrefab.Prefab, prefabTransform.position, Quaternion.identity);
                }
        }

        private void FixedUpdate()
        {
            if (inputControlls.Horizontal > 0.1f || inputControlls.Horizontal < 0.1f
                || inputControlls.VerticalVelocity > 0.1f || inputControlls.HorizontalVelocity < 0.1f)
            {
                if ((inputControlls.Horizontal >= 1 && inputControlls.Vertical >= 1) || (inputControlls.Horizontal <= 1 && inputControlls.Vertical <= 1))
                    rb.velocity = new Vector2((inputControlls.Horizontal * inputControlls.HorizontalVelocity) / 2, (inputControlls.Vertical * inputControlls.VerticalVelocity) / 2);
                else
                    rb.velocity = new Vector2(inputControlls.Horizontal * inputControlls.HorizontalVelocity, inputControlls.Vertical * inputControlls.VerticalVelocity);
            }
        }

        private IEnumerator AttackDelay()
        {
            yield return attackDelay;
            shootingDelay = false;
        }
    }
}

