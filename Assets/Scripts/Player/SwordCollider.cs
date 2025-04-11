using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    [SerializeField] PolygonCollider2D rightSwordCollider;
    [SerializeField] PolygonCollider2D leftSwordCollider;
    [SerializeField] PlayerController playerController;

    void Update()
    {
        UpdateWeaponCollider();        
    }

    void UpdateWeaponCollider()
    {
        if (playerController.IsAttacking)
        {
            rightSwordCollider.enabled = playerController.IsLookingRight;
            leftSwordCollider.enabled = !playerController.IsLookingRight;
        }
        else
        {
            rightSwordCollider.enabled = false;
            leftSwordCollider.enabled = false;
        }
    }
}
