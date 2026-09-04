using UnityEngine;

public class CastBarController : MonoBehaviour
{
    [SerializeField] private GameObject castBar;
    
    public void ShowCastBar(float castPercent)
    {
        gameObject.SetActive(true);
        castBar.transform.localScale = new Vector3(castPercent, 1, 1);
    }

    public void HideCastBar()
    {
        gameObject.SetActive(false);
    }
}
