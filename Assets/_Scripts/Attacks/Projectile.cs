using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcade.PlayerSpaceShip.Fire
{
    [CreateAssetMenu(fileName = "New Attack", menuName = "Attack", order = 51)]
    public class Projectile : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float FlyDistance { get; private set; }

        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
