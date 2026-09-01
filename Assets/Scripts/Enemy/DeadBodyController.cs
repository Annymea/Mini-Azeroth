using UnityEngine;
using UnityEngine.Events;

public class DeadBodyController : MonoBehaviour
{
    [SerializeField] private float despawnTime;

    [Header("Events")]
    public UnityEvent despawn;
    private float timeAlive = 0;

  

    private void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= despawnTime)
        {
            despawn.Invoke();
        }
    }

   
}
