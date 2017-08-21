using UnityEngine;

/// <summary>
/// Playable Character.
/// Defines what the player character can do.
/// </summary>
public class PlayableCharacter : MonoBehaviour, ICharacter
{
    public void Attack()
    {
        Debug.Log("I'm Attacking!!!");
    }

    public void Ultimate()
    {
        Debug.Log("I'm using my Ultimate Ability!!!!");
    }
}
