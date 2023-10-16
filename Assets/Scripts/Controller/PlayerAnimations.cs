using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    protected Animator animator;
    protected CharactersController controller;
    protected CharacterStatusController StatusController;
    
    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharactersController>();
        StatusController = GetComponent<CharacterStatusController>();
    }
}
