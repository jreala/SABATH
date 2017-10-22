using UnityEngine;
using System;
using System.Collections;

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

    [SerializeField]
    private GameObject attackHitbox;

    void Awake()
    {
        ToNextLevel = CalculateExperienceToLevel();
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * MovementSpeed;
    }

    public void Attack()
    {
        Debug.Log("I'm Attacking!!!");
        StartCoroutine("Swing");
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

    IEnumerator Swing()
    {
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackHitbox.SetActive(false);
    }
}