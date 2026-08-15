using UnityEngine;
using UnityEngine.Events;

public class VisionController : MonoBehaviour
{
    public UnityEvent<Transform> onSight;
    public UnityEvent outOfSight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        onSight.Invoke(collision.gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        outOfSight.Invoke();
    }
}
