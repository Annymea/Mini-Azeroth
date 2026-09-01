using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject player;
    public GameObject wolf;

    public float attackRange;
    public SpriteRenderer sprite;

    private void Awake()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    private void Update()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);

        Vector2 playerPos = player.transform.position;
        Vector2 wolfPos = wolf.transform.position;
        Vector2 direction = new Vector2(wolfPos.x - playerPos.x, wolfPos.y - playerPos.y);

        transform.up = direction;

        //Debug.Log(Vector2.Distance(playerPos, wolfPos) + " , " + transform.localScale);
     
        transform.localScale = new Vector3(1,Vector2.Distance(playerPos, wolfPos), 1);

        if(Vector2.Distance(playerPos, wolfPos) <= attackRange)
        {
            Color color = Color.red;
            sprite.material.color = color;
        }
        else
        {
            Color color = Color.white;
            sprite.material.color = color;
        }
    }
}
