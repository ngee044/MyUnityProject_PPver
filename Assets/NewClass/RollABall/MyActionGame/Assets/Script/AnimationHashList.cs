using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHashList : MonoBehaviour
{
    public static readonly int IsAttackHash = Animator.StringToHash("IsAttack");
    public static readonly int IsDeadHash = Animator.StringToHash("IsDead");
    public static readonly int IsWalkHash = Animator.StringToHash("IsMove");
}
