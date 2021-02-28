using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.3F;

   [SerializeField] GameObject player;

    // Caching the player reference in Start saves search costs later.
    void Start()
    {
        player = GameObject.Find("Player");
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }
}
