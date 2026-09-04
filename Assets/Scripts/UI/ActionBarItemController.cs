using UnityEngine;

public class ActionBarItemController : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject containSpell;

    public void Select(bool selected)
    {
        selection.SetActive(selected);
    }

    public GameObject GetContainedSpell()
    {
        return containSpell;
    }
}
