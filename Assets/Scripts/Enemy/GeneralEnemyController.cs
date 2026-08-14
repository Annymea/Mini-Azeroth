using UnityEngine;

public class GeneralEnemyController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject healthBarContainer;
    [SerializeField] private GameObject deadBody;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;

    private HealthbarController healthBar;
    private bool moveToSpawn = false;


    private void Awake()
    {
        healthBar = healthBarContainer.GetComponent<HealthbarController>();
        healthBar.setMaxHealth(maxHealth);
    }

    private void Update()
    {

        if (healthBar.GetMaxHealth() == healthBar.GetCurrentHealth())
        { 
            healthBar.showHealthbar(false);
            
        }
        else
        {
            healthBar.showHealthbar(true);
        }

        Vector2 movement = body.linearVelocity;
        bool isRunning = movement.x != 0 || movement.y != 0;
        animator.SetBool("Running", (isRunning));

        if(movement.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

    }

    private void FixedUpdate()
    {
        

        if (moveToSpawn)
        {
            //move back to spawner
            Vector2 spawnerPos = gameObject.transform.parent.transform.position;
            MoveTo(spawnerPos);
            if(body.linearVelocity == new Vector2(0, 0))
            {
                moveToSpawn = false;
            }
        }

        //if(body.linearVelocityY < 0)
        //{
        //    transform.Rotate(0f, 180f, 0f);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject attack = collision.gameObject;
        AttackController attackController = attack.GetComponent<AttackController>();
        if (attackController == null)
            return;

        healthBar.DoDamage(attackController.GetDamage());

        if (!healthBar.IsAlive())
        {
            Instantiate(deadBody, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(gameObject);
        }
    }

    public void OnEnemySight(Vector2 playerPos)
    {
        MoveTo(playerPos);
    }

    public void OnEnemyOutOfSight()
    {
        moveToSpawn = true;
        
    }

    public void MoveTo(Vector2 to)
    {
        Vector2 from = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = to - from;
        body.linearVelocity = direction.normalized * moveSpeed;

        if ((from - to).sqrMagnitude < 0.2 )
            body.linearVelocity = new Vector2(0, 0);
    }

    
}
