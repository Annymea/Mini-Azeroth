using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float respawnTime;

    private bool isDead;
    private float timeDead = 0;

    private void Awake()
    {
        SpawnWolf();
    }

    private void Update()
    {

        int test = transform.childCount;
        
        if(test == 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        if (isDead)
        {
            timeDead += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (timeDead >= respawnTime) {
            SpawnWolf();
        }
    }

    private void SpawnWolf()
    {
        Instantiate(
            enemy, 
            new Vector3(transform.position.x, transform.position.y), 
            transform.rotation, 
            transform
            );

        timeDead = 0;
    }
}
