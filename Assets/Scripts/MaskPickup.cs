using UnityEngine;

public class MaskPickup : InteractiveObject
{
    public override void OnInteract()
    {
        Debug.Log($"MASK PICKUP triggered on: {gameObject.name}");

        PlayerController.instance.hasMask = true;

        // optional: auto-equip
        // PlayerController.instance.isWearingMask = true;

        Destroy(gameObject);
    }
}
