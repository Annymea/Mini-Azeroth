using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D body;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Update()
    {
        animator.SetFloat("VelocityX", Mathf.Abs(body.linearVelocityX));
        animator.SetFloat("VelocityY", Mathf.Abs(body.linearVelocityY));

        if(body.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(body.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    

}
