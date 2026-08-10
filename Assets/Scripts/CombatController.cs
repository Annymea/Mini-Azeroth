using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private GameObject frostbolt;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform aimer;

    private InputSystem_Actions actions;
    private Vector3 mousePos;
    private bool isShooting;
    

    private void Awake()
    {
        actions = new InputSystem_Actions();
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
        if (actions.Combat.Shoot.triggered)
        {
            isShooting = true;
        }

        Vector2 worldPos = actions.Combat.Aim.ReadValue<Vector2>();
        
        mousePos = cam.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y));
        
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            Shoot();
            isShooting = false;
        }
    }

    private void Shoot()
    {
        Vector2 direction = mousePos - aimer.position;
        aimer.up = direction;
        GameObject newSpell = Instantiate(frostbolt, new Vector3(aimer.position.x, aimer.position.y), aimer.rotation);
        newSpell.GetComponent<ProjectileController>().Shoot(direction);
      
    }
}
