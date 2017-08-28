using System.Collections;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public PlayableCharacter character;
    private static bool CanSwing = true;

    public void OnTouchDown(object args)
    {
        Debug.Log("Swinging");
        if (CanSwing)
        {
            CanSwing = false;
            character.Attack();
            StartCoroutine(AttackCooldown());
        }
    }

    public void OnTouchUp()
    {
    }

    public void OnTouchStay()
    {
    }

    public void OnTouchExit()
    {
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        CanSwing = true;
    }
}
