 using UnityEngine;
 
 public class CameraFollow : MonoBehaviour
 {
     public Transform playerTransform;
     public int depth = -20;
     private Vector3 offset;
     
     // Update is called once per frame
     void Update()
     {
         if(playerTransform != null)
         {
//             transform.position = playerTransform.position + new Vector3(0,10,depth);
             transform.position = new Vector3(
                 playerTransform.position.x,
                 playerTransform.position.y + 5,
                 playerTransform.position.z - 10);

             transform.rotation = playerTransform.rotation;
         }
     }
 
     public void setTarget(Transform target)
     {
         playerTransform = target;
     }
 }