using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openOffset = new Vector3(0, 3f, 0);
    private Vector3 closedPos;

    void Start()
    {
        closedPos = transform.position;
    }

    public void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        transform.position = closedPos + openOffset;
        Debug.Log("Door opened!");
    }
}
