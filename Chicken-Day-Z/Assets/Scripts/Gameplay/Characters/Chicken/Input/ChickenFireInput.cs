using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Inventory.ItemActions;

public class ChickenFireInput : MonoBehaviour
{
    [SerializeField] private CharacterItemActionController _itemActionController;
            
    [SerializeField][Range(0, 2)] private int _fireMouseButton;

    void Update()
    {
        FireInput();       
    }

    private void FireInput() 
    {
        if (Input.GetMouseButtonDown(_fireMouseButton)) 
        {
            if (_itemActionController != null) 
            {
                _itemActionController.ExecuteAction = true;
            }            
        }
    }
}