using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour

{   // Animation
    // [SerializedField] private float animationspeed;
    // private Animator animator;
    // private SkinnedMeshRenderer mesh;
    // private float gripTarget;
    // private float triggerTarget;
    // private float gripCurrent;
    // private float triggerCurrent;
    // private const string animatorGripParam = "Grip";
    // private const string animatorTriggerParam = "Trigger";
    // private static readonly int Grip = Animator.StingToHash(AnimatorGripParam);
    // private static readonly int Trigger = Animator.StingToHash(AnimatorTriggerParam);

    // Physics Movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;
   
     private void Start()
    {
        // Animation
        // _animator = GetComponent<Animator>();
        // _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        
        //Physics Movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;
       
       // Teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    private void Update()
    {
       // AnimatorHand();

          PhysicsMove();
    }

    private void PhysicsMove()
    {
    // Position 
    var positionWithOffset = _followTarget.TransformPoint(positionOffset);
    var distance = Vector3.Distance(positionWithOffset, transform.position);
    _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);
    // Rotation
    var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
    var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
    q.ToAngleAxis(out float angle, out Vector3 axis);
    _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

   }


 // internal void SetGrip(float v)
 // {
 //    _gripTarget = v;
 // }
 //  internal void SetTrigger(float v)
 //  {
 //      _triggerTarget = v;
 //  }
 //   private void AnimatorHand()
 //   {
 //       if (Math.Abs(gripCurrent - _gripTarget) > 0)
 //       {
 //           _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * speed);
 //           _animator.SetFloat(Grip, _gripCurrent);
 //       }
 //        if (!(Math.Abs(_triggerCurrent - _triggerTarget) > 0)) return;
 //       {
 //           triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
 //           animator.SetFloat(animatorTriggerParam, triggerCurrent);
 //       }
 //   }

 //   public void ToggleVisibility()
 //   {
 //       mesh.enabled = !mesh.enabled;
 //   }
} 
