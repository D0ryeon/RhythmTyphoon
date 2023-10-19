using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Collider2D;
    [SerializeField] private float InputTime = 0.05f;
    private Coroutine TimeChekcing;
    private bool IsChecking;

    public int checkNote = 0;

    private void Start()
    {
        Collider2D.enabled = false;
        IsChecking = false;
    }
    void OnAttack()
    {
        if (IsChecking)
            StopCoroutine(TimeChekcing);
        TimeChekcing = StartCoroutine(TimeCheck());
    }
    private IEnumerator TimeCheck()
    {
        IsChecking = true;
        Collider2D.enabled = true;

        yield return new WaitForSeconds(InputTime);

        IsChecking = false;
        Collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

         Debug.Log(checkNote);
        checkNote++;
    }
}
