using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Character")]
public class CharacterData : ScriptableObject
{
    public float Speed;
    public Sprite DefaultSprite;
    public AnimatorController Animator;
}
