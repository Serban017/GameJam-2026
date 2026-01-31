using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public virtual void OnInteract()
    {
        Debug.Log($"Interacted with BASE InteractiveObject on: {gameObject.name}");
    }
}
