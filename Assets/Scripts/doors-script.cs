using UnityEngine;
using TMPro;

// Enum to define different types of bonuses the doors can have
public enum BonusType
{
    Addition,
    Difference,
    Product,
    Division
}

public class Doors : MonoBehaviour
{
    // Elements References
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider doorsCollider;

    // Door Settings
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    [SerializeField] private int leftDoorBonusAmount;
    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    private void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        // Configure right door
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "×" + rightDoorBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "÷" + rightDoorBonusAmount;
                break;
        }

        // Configure left door
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;
            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "×" + leftDoorBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "÷" + leftDoorBonusAmount;
                break;
        }
    }

    // Returns the bonus type based on player position
    public BonusType GetBonusType(float xPosition)
    {
        return xPosition > 0 ? rightDoorBonusType : leftDoorBonusType;
    }

    // Returns the bonus amount based on player position
    public int GetBonusAmount(float xPosition)
    {
        return xPosition > 0 ? rightDoorBonusAmount : leftDoorBonusAmount;
    }

    // Disables the door collider after interaction
    public void Disable()
    {
        doorsCollider.enabled = false;
    }
}
