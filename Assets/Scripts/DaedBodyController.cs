using UnityEngine;

public class DaedBodyController : MonoBehaviour
{
    [SerializeField] private float despawnTime;

    private float timeAlive = 0;

    private void Update()
    {
        timeAlive += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(timeAlive >= despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
