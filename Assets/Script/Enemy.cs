// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
// public class Enemy : MonoBehaviour
// {
//     public int maxHealth;
//     public int curHealth;

//     // public Transform Target;

//     Rigidbody rigid;
//     BoxCollider boxCollider;
//     Material mat;
//     NavMeshAgent nav;

//     void Awake()
//     {
//         rigid = GetComponent<Rigidbody>();
//         boxCollider = GetComponent<BoxCollider>();
//         mat = GetComponent<MeshRenderer>().material;
//         nav = GetComponent<NavMeshAgent>();

//     }

//     void Update()
//     {
//        nav.SetDestination(target.position);
//     }

//     void FreezeVelocity()
//     {
//         rigid.velocity = Vector3.zero;
//         rigid.angularVelocity = Vector3.zero;
//     }


//     void FixedUpdate()
//     {
//         FreezeVelocity();
//     }

//     void OnTriggerEnter(Collider other)
//     {
       

//         //원거리 공격(손전등)
//         if (other.tag == "FlashLight") {
//             Weapon flashlight = other.GetComponent<FlashLight>();
//             curHealth -= FlashLight.damage;
//             StartCoroutine(OnDanmage());
//            Debug.Log("Range ; " + curHealth);
//         }

//     }
            
//     //피격 로직
//     IEnumerator OnDanmage()
//     {
//         mat.color = Color.red;
//         yield return new WaitForSeconds(0.1f);

//         if(curHealth > 0) {
//             mat.color = Color.white;
//         }
//         else{
//             mat.color = Color.gray;
//             Destroy(gameObject,4);
//         }
//     }
// }
