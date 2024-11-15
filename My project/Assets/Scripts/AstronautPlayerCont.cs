using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayerCont : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;
		public bool CanMove = false;
		public float speed = 600.0f;
		public float runningSpeed = 1200.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		public void MoveMake(bool X){
			CanMove = X;
		}

		void Update (){
			if(CanMove){
				if (Input.GetKey ("w")) {
					anim.SetInteger ("AnimationPar", 1);
				}  else if (Input.GetKey ("s")) {
					anim.SetInteger ("AnimationPar", 1);
				}  else {
					anim.SetInteger ("AnimationPar", 0);
				}

				if (Input.GetKey ("left shift") && controller.isGrounded) {
					moveDirection = transform.forward * Input.GetAxis("Vertical") * runningSpeed;
				} else if (controller.isGrounded){
					moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
				}

				/*if(controller.isGrounded){
					moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
				}*/

				float turn = Input.GetAxis("Horizontal");
				transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
				controller.Move(moveDirection * Time.deltaTime);
				moveDirection.y -= gravity * Time.deltaTime;
			}else{
				anim.SetInteger ("AnimationPar", 0);
			}
		}
	}
}
