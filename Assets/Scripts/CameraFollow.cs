 using UnityEngine;
 
 public class CameraFollow : MonoBehaviour
 {
     public Transform playerTransform;
     private Vector3 offset;

    public float distance = 5;
    public float height = 5;

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
     {
        if (playerTransform != null)
        {
            Vector3 playerMoveDir = playerTransform.forward;

            if (playerMoveDir != Vector3.zero)
            {
                playerMoveDir.Normalize();
                transform.position = playerTransform.position - playerMoveDir * distance;
                transform.position = transform.position + new Vector3(0, height, 0);
            }
            transform.LookAt(playerTransform.position);
        }
     }
 
     public void setTarget(Transform target)
     {
         playerTransform = target;
     }
 }