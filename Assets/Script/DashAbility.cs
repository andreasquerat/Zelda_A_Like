using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Scriptable Object/Ability/Dash Ability", fileName = "Dash Ability")]

public class DashAbility : GenericAbility
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection,
       Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        //Make sure the player has enough stamina
        if (playerStamina.value >= staminaCost)
        {
            playerStamina.value -= staminaCost;
            usePlayerStamina.Raise();
        }
        else
        {
            return;
        }
        if (playerRigidbody)
        {
            Vector3 dashVector = playerRigidbody.transform.position + (Vector3)playerFacingDirection.normalized * dashForce;
            playerRigidbody.DOmove(dashVector, duration);
        }
    }
}
