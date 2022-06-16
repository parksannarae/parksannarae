using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
	public Item item;
	public void SetItem(Item _item)
	{
		item.type = _item.type;
	}

	public Item GetItem()
	{
		return item;
	}

	public bool hasTool = false;
	public bool hasFood = false;
    // 캐릭터의 초기 값
    public int gotTool = 0;
    public int gotFood = 0;
    
    private int maxTool = 50;
    private int maxFood = 40;

	//
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
		// https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// make sure we only push desired layer(s)
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) return;

		// Calculate push direction from move direction, horizontal motion only
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		// Apply the push and take strength into account
		body.AddForce(pushDir * strength, ForceMode.Impulse);
	}
	//추가 박산나래


	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") 
        {
           if(item.type == Type.Tool)
		   {
                gotTool++;
                if (gotTool >= maxTool)
				{
                    hasTool = true;
				}
		   }
		  else if( item.type == Type.Food)
		  {
                if (gotFood >= maxFood)
			    {
                    hasFood = true;
			    }
		    }
		}
		Destroy(other.gameObject);
	}
}