using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
