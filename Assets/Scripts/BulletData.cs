using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Bullet")]
public class BulletData : ScriptableObject
{
    public float Speed;
    public int Damage;
    public Sprite DefaultSprite;
    public AnimatorController Animator;
}
