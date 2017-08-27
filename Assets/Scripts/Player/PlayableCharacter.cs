using UnityEngine;
using System;

/// <summary>
/// Playable Character.
/// Defines what the player character can do.
/// </summary>
public class PlayableCharacter : MonoBehaviour, ICharacter
{
    public int Level;
    public int AttackValue;
    public int MovementSpeed;
    public double ToNextLevel;
    public double ExperiencePoints;
    
    private float base_exp = 25f;
    private float factor = 1.1f;

    void Awake()
    {
        Debug.Log("Hit");
        ToNextLevel = CalculateExperienceToLevel();
    }

    public void Attack()
    {
        Debug.Log("I'm Attacking!!!");
    }

    public void Ultimate()
    {
        Debug.Log("I'm using my Ultimate Ability!!!!");
    }

    public void LevelUp()
    {
        ExperiencePoints = ExperiencePoints % ToNextLevel;
        if (Level % 2 == 0)
        {
            AttackValue++;
        }

        AttackValue++;
        Level++;
    }

    public void AddExperience(double exp)
    {
        ExperiencePoints += exp;
    }

    public double CalculateExperienceToLevel()
    {
        return Math.Floor(base_exp * Math.Pow(Level + 1, factor));
    }
}