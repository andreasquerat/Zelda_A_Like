using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Object/Ability/Generic Ability", fileName = "Generic Ability")]

public class GenericAbility : ScriptableObject
{
    public float staminaCost;
    public float duration;

    public FloatValue playerStamina;
    public Notification usePlayerStamina;



    public virtual void Ability(Vector2 playerPosition, Vector2 playerFacingDirection,
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {

    }
}
