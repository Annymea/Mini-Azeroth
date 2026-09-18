using UnityEngine;

public class ShadowCasterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer sourceRenderer;
    [SerializeField] private SpriteRenderer shadowRenderer;

    [Header("Shadow")]
    [SerializeField] private Vector2 shadowDirection = new Vector2(1f, -1f);
    [SerializeField] private float shadowLength = 0.7f;
    [SerializeField] private float shadowDistance = 0.3f;
    [SerializeField] private float shadowAlpha = 0.35f;

    private void Awake()
    {
        UpdateShadow();
    }

    private void LateUpdate()
    {
        shadowRenderer.sprite = sourceRenderer.sprite;
    }

    private void UpdateShadow()
    {
        shadowDirection.Normalize();

        // Gleiches Sprite verwenden
        shadowRenderer.sprite = sourceRenderer.sprite;

        // Schwarz + transparent
        shadowRenderer.color =
            new Color(0f, 0f, 0f, shadowAlpha);

        // Schattenebene
        shadowRenderer.sortingLayerName = "Shadows";

        // Vom Objekt weg bewegen
        shadowRenderer.transform.localPosition =
            shadowDirection * shadowDistance;

        // Sprite "auf den Boden legen"
        shadowRenderer.transform.localScale =
            new Vector3(1f, -shadowLength, 1f);

        // Schatten in Sonnenrichtung drehen
        float angle = Vector2.SignedAngle(
            Vector2.down,
            shadowDirection
        );

        shadowRenderer.transform.localRotation =
            Quaternion.Euler(0f, 0f, angle);
    }
}
