using System;
using UnityEngine;

public class ActionBarItemController : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject containSpell;
    [SerializeField] private GameObject showCooldown;

    public void ShowCooldown(float cooldownPercentage)
    {
        if(cooldownPercentage >= 1)
        {
            showCooldown.SetActive(false);
            return; 
        }

        showCooldown.SetActive(true);
        showCooldown.transform.localScale = new Vector3(1, 1 - cooldownPercentage, 1);
    }

    public void Select(bool selected)
    {
        selection.SetActive(selected);
    }

    public GameObject GetContainedSpell()
    {
        return containSpell;
    }
}
