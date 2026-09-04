using UnityEngine;

public class ActionBarController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject[] actionBarItems;


    private InputSystem_Actions actions;
    private int activeElement = 0;


    private void Awake()
    {
        actions = new InputSystem_Actions();
        SetActive(true);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        if (actions.UI.ScrollActions.ReadValue<Vector2>().y > 0)
        {
            ScrollUp();
            Debug.Log("up");
        }
        if (actions.UI.ScrollActions.ReadValue<Vector2>().y < 0)
        {
            ScrollDown();
            Debug.Log("down");
        }
    }

    private void ScrollUp()
    {
        SetActive(false);

        activeElement --;
        if(activeElement < 0)
        {
            activeElement = actionBarItems.Length - 1;
        }

        SetActive(true);
    }

    private void ScrollDown()
    {
        SetActive(false);

        activeElement ++;
        if(activeElement >= actionBarItems.Length)
        {
            activeElement = 0;
        }

        SetActive(true);
    }


    private void SetActive(bool active)
    {
        ActionBarItemController itemController = actionBarItems[activeElement].GetComponent<ActionBarItemController>();
        if (itemController == null) return;

        itemController.Select(active);
    }
}
