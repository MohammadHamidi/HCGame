using UnityEngine;
using TMPro;
using System;

// Enum to define different types of bonuses the doors can have
public enum BonusType
{
    Addition,// Add +
    Difference,// Subtract -
    Product, // Multiply *
    Division // '/.
}


// Player -> Door ( + *) (- , /)

public class Doors : MonoBehaviour
{

    [Header("Bouns Type")]
    [SerializeField] private BonusType rightDoorBonusType;

    [SerializeField] private int rightDoorBonusAmount;
    [SerializeField] private Color bonusColor;
    [Space]
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    
    [SerializeField] private Color penaltyColor;
    [Space(3)]

    [Header("Sprite Refrneces")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [Space(3)]
    [Header("Text Refrneces")]
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    
    [Space(3)]
    [Header("Doors Collider")]

    [SerializeField] private Collider doorsCollider;

    
    


    // Configure the Doors 



    private void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorText.text = $"+ {rightDoorBonusAmount}";
                break;
            case BonusType.Difference:
                rightDoorText.text = $"- {rightDoorBonusAmount}";
                break;
            case BonusType.Product:
                rightDoorText.text = $"x {rightDoorBonusAmount}";
                break;
            case BonusType.Division:
                rightDoorText.text = $"/ {rightDoorBonusAmount}";
                break;
        }
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorText.text = $"+ {leftDoorBonusAmount}";
                break;
            case BonusType.Difference:
                leftDoorText.text = $"- {leftDoorBonusAmount}";
                break;
            case BonusType.Product:
                leftDoorText.text = $"x {leftDoorBonusAmount}";
                break;
            case BonusType.Division:
                leftDoorText.text = $"/ {leftDoorBonusAmount}";
                break;
        }
        ChangeDoorColor(leftDoorRenderer, leftDoorBonusType);
        ChangeDoorColor(rightDoorRenderer, rightDoorBonusType);
    }

    private void ChangeDoorColor(SpriteRenderer doorSpriteRenderer, BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                doorSpriteRenderer.color = bonusColor;
                break;
            case BonusType.Difference:
                doorSpriteRenderer.color = penaltyColor;
                break;
            case BonusType.Product:
                doorSpriteRenderer.color = bonusColor;
                break;
            case BonusType.Division:
                doorSpriteRenderer.color = penaltyColor;
                break;
        }
    }

    public BonusType GetBonusType()
    {
        return rightDoorBonusType;
    }

    public int GetBonusAmount()
    {
        return rightDoorBonusAmount;
    }


    // Returns the bonus type based on player position
    public BonusType GetBonusType(float xPosition)
    {

        if (xPosition > 0)
        {
            //right
        }
        else
        {
            //left
        }

        var returningValue = xPosition > 0 ? rightDoorBonusType : leftDoorBonusType;
        return returningValue;
        //return xPosition > 0 ? rightDoorBonusType : leftDoorBonusType;
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
