using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        transform.position = player.transform.position;
    }


    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
