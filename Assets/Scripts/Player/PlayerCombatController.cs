using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    private enum AttackState
    {
        idle, cast, attack, release
    }


    [SerializeField] private Camera cam;
    [SerializeField] private Transform castLauncher;
    [SerializeField] private CastBarController cast;
    [SerializeField] private ActionBarController spells;

    private InputSystem_Actions actions;
    private GameObject currentSpell;
    private float currentSpellCastDuration;
    private float castTimer = 0;
    private Vector3 mousePos;
    private AttackState state = AttackState.idle;


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

    private bool IsPressed()
    {
        return actions.Combat.Cast.IsPressed();
    }

    private void Update()
    {

        CheckInputs();
        ExecuteState();
    }

    private void ExecuteState()
    {
        switch (state)
        {
            case AttackState.idle:
                castTimer = 0;
                cast.HideCastBar();
                break;
            case AttackState.cast:
                castTimer += Time.deltaTime;
                cast.ShowCastBar(castTimer / currentSpellCastDuration);
                break;
            case AttackState.attack:
                Vector2 worldPos = actions.Combat.Aim.ReadValue<Vector2>();
                mousePos = cam.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y));

                cast.HideCastBar();
                Shoot();
                state = AttackState.release;
                break;
        }
    }

    private void CheckInputs()
    {
        switch (state)
        {
            case AttackState.idle:
                if (IsPressed())
                {
                    GetCurrentSpell();
                    spells.StartGlobalCooldown();
                    state = AttackState.cast;
                }
                break;
            case AttackState.cast:
                if (!IsPressed())
                {
                    state = AttackState.idle;
                }
                if (IsPressed())
                {
                    if (castTimer >= currentSpellCastDuration)
                    {
                        state = AttackState.attack;
                        castTimer = 0;
                    }
                }
                break;
            case AttackState.release:
                if (!IsPressed())
                {
                    state = AttackState.idle;
                }
                break;
        }
    }

    private void GetCurrentSpell()
    {
        currentSpell = spells.GetCurrentSpell();
        if (currentSpell == null) return;

        RangedSpellController spellControler = currentSpell.GetComponent<RangedSpellController>();
        
        currentSpellCastDuration = spellControler.GetCastDuration();
    }

    private void Shoot()
    {  
        Vector2 direction = mousePos - castLauncher.position;
        castLauncher.up = direction;

        GameObject newSpell = Instantiate(
            currentSpell, 
            new Vector3(castLauncher.position.x, castLauncher.position.y), 
            castLauncher.rotation
            );

        IPlayerRangedAttack newSpellController = newSpell.GetComponent<IPlayerRangedAttack>();
        if (newSpellController == null) return;

        Transform player = gameObject.transform;
        newSpellController.Shoot(direction, player);

    }
}
