using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");

    [SerializeField] private Animator animator;

    private PlayerController playerController;

    void Start()
    {
        playerController = PlayerController.Instance;
    }

    void Update()
    {
        animator.SetBool(isWalking, playerController.isWalking);
    }
}
