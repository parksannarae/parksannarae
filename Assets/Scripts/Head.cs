using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform rootObject, followObject;
    [SerializeField] Vector3 positionOffset, rotartionOffset, headBodyOffset;
  
    private void LateUpdate()
    {
        rootObject.position = transform.position + headBodyOffset;
        rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;
        
        transform.position = followObject. TransformPoint(positionOffset);
        transform.rotation = followObject.rotation * Quaternion.Euler(rotartionOffset);
    }
}
