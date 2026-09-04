using System;
using UnityEngine;

public class ActionBarItemController : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject containSpell;
    [SerializeField] private GameObject showCooldown;

    private bool onCooldown = false; 

    public void ShowCooldown(float cooldownPercentage)
    {
        if(cooldownPercentage >= 1)
        {
            onCooldown = false;
        }
        else
        {
            onCooldown = true;
            showCooldown.transform.localScale = new Vector3(1, 1 - cooldownPercentage, 1);
        }

        showCooldown.SetActive(onCooldown);
    }

    public void Select(bool selected)
    {
        selection.SetActive(selected);
    }

    public GameObject GetContainedSpell()
    {
        if(!onCooldown)
            return containSpell;

        return null;
    }
}
