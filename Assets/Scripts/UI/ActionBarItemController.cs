using System;
using UnityEngine;

public class ActionBarItemController : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject containSpell;
    [SerializeField] private GameObject showCooldown;

    private bool onCooldown = false;
    private float cooldownDuration = 5;
    private float cooldownTimer = 0;

    private void Update()
    {
        if (!onCooldown) return;

        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= cooldownDuration)
        {
            onCooldown = false;
            cooldownTimer = 0; 
            showCooldown.SetActive(onCooldown);
        }

        showCooldown.SetActive(onCooldown);
        ShowCooldown(cooldownTimer / cooldownDuration);

    }

    public void ShowCooldown(float cooldownPercentage)
    {
        showCooldown.transform.localScale = new Vector3(1, 1 - cooldownPercentage, 1);
    }

    public void StartGlobalCooldown(float cooldownDuration)
    {
        if (onCooldown) return; 

        this.cooldownDuration = cooldownDuration;
        onCooldown = true;
    }

    public void StartSpellCooldown()
    {
        RangedSpellController spell = containSpell.GetComponent<RangedSpellController>();
        if (spell == null) return;

        cooldownDuration = spell.GetCooldownDuration();
        onCooldown = true;
    }

    public void Select(bool selected)
    {
        selection.SetActive(selected);
    }

    public bool ContainsSpell(GameObject spell)
    {
        return spell == containSpell;
    }

    public GameObject GetContainedSpell()
    {
        if(!onCooldown)
            return containSpell;

        return null;
    }
}
