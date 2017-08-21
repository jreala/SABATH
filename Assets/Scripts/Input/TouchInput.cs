using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour
{

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit2D hit;

    void Update()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.Raycast(ray.origin, ray.direction);
#pragma warning disable 472
            if (hit != null && hit.collider != null)
#pragma warning restore 472
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
            // No longer being held down
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    if (g.activeInHierarchy)
                    {
                        g.SendMessage("OnTouchExit");
                    }
                }
            }
        }
#endif

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
#pragma warning disable 472
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit != null && hit.collider != null)
#pragma warning restore 472
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            // No longer being held down
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit");
                }
            }
        }
    }
}