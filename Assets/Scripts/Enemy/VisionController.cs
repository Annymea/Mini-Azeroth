using UnityEngine;
using UnityEngine.Events;

public class VisionController : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<Transform> foundPlayer;
    public UnityEvent lostPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        foundPlayer.Invoke(collision.gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        lostPlayer.Invoke();
    }
}
