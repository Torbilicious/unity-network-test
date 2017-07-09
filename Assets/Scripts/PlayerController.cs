using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody body;
    private RaycastHit hit;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!isLocalPlayer) return;

        var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        if ((Input.GetKeyDown ("space") || CrossPlatformInputManager.GetButtonDown("Jump")) && !isFalling(body)) {
            Vector3 up = transform.TransformDirection (Vector3.up);
            body.AddForce (up * 5, ForceMode.Impulse);
        }
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }

    private bool isFalling(Rigidbody rigidbody)
    {
        Ray downRay = new Ray(rigidbody.transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(downRay, out hit))
        {
            var distance = hit.distance;

            return distance > 1.1;
        }

        return true;
    }
}