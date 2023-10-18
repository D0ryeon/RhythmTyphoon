using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D Collider2D;
  
    void OnAttack()
    {
        Collider2D.enabled = true;
    }
}
