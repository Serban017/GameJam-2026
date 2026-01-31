using UnityEngine;
using TMPro;

public class RevealWithMask : MonoBehaviour
{
    MeshRenderer meshRend;
    TMP_Text tmpText;

    void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
        tmpText = GetComponent<TMP_Text>();

        Debug.Log($"[RevealWithMask] Awake on {name} | MeshRenderer={(meshRend != null)} | TMP_Text={(tmpText != null)}");
    }

    void Start()
    {
        // Hide at start (whichever component exists)
        if (meshRend != null) meshRend.enabled = false;
        if (tmpText != null) tmpText.enabled = false;
    }

    void Update()
    {
        if (PlayerController.instance == null)
        {
            Debug.LogWarning($"[RevealWithMask] PlayerController.instance is NULL (on {name})");
            return;
        }

        bool show = PlayerController.instance.isWearingMask;

        // Toggle whichever exists
        if (meshRend != null && meshRend.enabled != show)
            meshRend.enabled = show;

        if (tmpText != null && tmpText.enabled != show)
            tmpText.enabled = show;
    }
}
