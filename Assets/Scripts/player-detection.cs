using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private CrowdSystem crowdSystem;
    
    private void Update()
    {
        DetectDoors();
    }

    private void DetectDoors()
    {




        //// Create a sphere around the player to detect nearby colliders
        ////Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1f);
        Collider[] detected = Physics.OverlapSphere(transform.position, 1f);

        foreach (var item in detected)
        {
            Doors target = item.GetComponent<Doors>();
            if (target != null)
            {
                var type=target.GetBonusType(transform.position.x);
                var amount = target.GetBonusAmount(transform.position.x);
                crowdSystem.ApplyEffect(type,amount);
                target.gameObject.SetActive(false);

            }
        }


        //foreach (var collider in detectedColliders)
        //{
        //    // Try to get the Doors component from the detected collider
        //    if (collider.TryGetComponent<Doors>(out Doors doors))
        //    {
        //        // Get the bonus type and amount based on player's position
        //        BonusType bonusType = doors.GetBonusType(transform.position.x);
        //        int bonusAmount = doors.GetBonusAmount(transform.position.x);

        //        // Apply the bonus to the crowd system
        //        crowdSystem.ApplyBonus(bonusType, bonusAmount);

        //        // Disable the door after interaction
        //        doors.Disable();
        //    }
        //}
    }
}
