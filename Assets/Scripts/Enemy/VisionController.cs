using UnityEngine;
using UnityEngine.Events;

public class VisionController : MonoBehaviour
{
    public UnityEvent<Vector2> onSight;
    public UnityEvent outOfSight;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerController>() == null)
            return;

        onSight.Invoke(collision.gameObject.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerController>() == null)
            return;

        outOfSight.Invoke();
    }
}
