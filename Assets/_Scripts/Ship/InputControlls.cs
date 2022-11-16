using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcade.PlayerSpaceShip.Ship.Movement
{
    [Serializable]
    public struct InputControlls
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float OriginalH { get; private set; }
        public float OriginalV { get; private set; }
        [field: SerializeField] public float HorizontalVelocity { get; private set; }
        [field: SerializeField] public float VerticalVelocity { get; private set; }

        public void CheckForInputs()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
        }

        public void VelocityBonus(int amount)
        {
            OriginalH = HorizontalVelocity;
            OriginalV = VerticalVelocity;

            HorizontalVelocity *= amount;
            VerticalVelocity *= amount;
        }

        public void SetDefaultValues()
        {
            HorizontalVelocity = OriginalH;
            VerticalVelocity = OriginalV;
        }
    }
}
