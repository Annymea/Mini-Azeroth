using UnityEngine;

public class ActionBarController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject[] actionBarItems;

    [Header("Stats")]
    [SerializeField] private float globalCooldown = 0.5f;

    private float cooldownTimer = 0;
    private bool globalCooldownRunning = false; 


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
        }
        if (actions.UI.ScrollActions.ReadValue<Vector2>().y < 0)
        {
            ScrollDown();
        }

        if (globalCooldownRunning)
        {
            cooldownTimer += Time.deltaTime;
            float globalCooldownPercentage = cooldownTimer / globalCooldown;

            for(int i = 0; i < actionBarItems.Length; i ++)
            {
                ActionBarItemController itemController = GetCurrentActionBarItemController(i);
                if (itemController == null) return;

                itemController.ShowCooldown(globalCooldownPercentage);
            }

            if(cooldownTimer >= globalCooldown)
            {
                cooldownTimer = 0;
                globalCooldownRunning = false;
            }
        }
    }

    public void StartGlobalCooldown()
    {
        Debug.Log("Hier");
        globalCooldownRunning = true; 
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
        ActionBarItemController itemController = GetCurrentActionBarItemController(activeElement);
        if (itemController == null) return;

        itemController.Select(active);
    }

    public GameObject GetCurrentSpell()
    {
        ActionBarItemController itemController = GetCurrentActionBarItemController(activeElement);
        if (itemController == null) return null;

        return itemController.GetContainedSpell();
    }

    private ActionBarItemController GetCurrentActionBarItemController(int index)
    {
        ActionBarItemController itemController = actionBarItems[index].GetComponent<ActionBarItemController>();
        if (itemController == null) return null;

        return itemController;
    }
}
