using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class GunPowerUpObject : PowerUpObject
    {
        [SerializeField] private FirearmStats[] _firearmStats;

        [SerializeField] private CharacterInventory _characterInventory;

        private static short _powerUpLevel;

        private GunPowerUpObject() : base(PowerUpObjectTypeEnum.GUN)
        {

        }        

        public override short GetPowerUpLevel()
        {
            return _powerUpLevel;
        }

        protected override void UsePowerUp()
        {
            if (PowerUpAvailable && !IsChestBlocked && _powerUpLevel < MaxLevel)
            {
                _characterInventory.FirearmStats = _firearmStats[_powerUpLevel];

                _powerUpLevel += 1;

                PowerUpAvailable = false;

                IsChestBlocked = true;
            }
        }

        protected override void ResetPowerUpLevel() 
        {
            _powerUpLevel = 0;
        }
    }
}