using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D uiBody;

    private Rigidbody2D playerBody;
    private Vector2 oldPosition;
    private bool playerMoved;

    private void Awake()
    {
        transform.position = player.transform.position;
        oldPosition = player.transform.position;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        //Debug.Log("old " + oldPosition);
        //Debug.Log("new " + (Vector2)player.transform.position);

        if ((Vector2)player.transform.position != oldPosition)
        {
            playerMoved = true;
        }
        else
        {
            playerMoved = false;
        }

        Debug.Log(playerMoved);

        oldPosition = player.transform.position;

        if (playerBody != null && playerMoved)
            uiBody.linearVelocity = playerBody.linearVelocity;
        else
            uiBody.linearVelocity = Vector2.zero;
    }
}
