using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Spawn
{
    public class PlayerSpawnPosition : MonoBehaviour, IResettable
    {
        [SerializeField] private GameObject _playersSpawnPosition;        
        
        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }        

        void Start()
        {
            SetPlayerPosition();
        }        

        public void ResetObject()
        {
            SetPlayerPosition();
        }        
        
        private void SetPlayerPosition() 
        {
            if (_playersSpawnPosition != null)
            {
                gameObject.transform.position = _playersSpawnPosition.gameObject.transform.position;
            }
            else
            {
                Debug.LogError("No spawn position assigned!");
            }
        }        
    }
}