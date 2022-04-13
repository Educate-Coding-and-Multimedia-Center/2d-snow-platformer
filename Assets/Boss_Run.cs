using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour {

	public float speed = 2f;
	public float moveRange = 4f;
	public float shootRange = 5f;

	Transform player;
	Rigidbody2D rb2d;

	IceDrakeScript boss;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		player = GameObject.FindGameObjectWithTag (MyTagsLayers.PLAYER_TAG).transform;
		rb2d = animator.GetComponent<Rigidbody2D> ();
		boss = animator.GetComponent<IceDrakeScript> ();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		if (Vector2.Distance(player.position, rb2d.position) <= moveRange) {
			boss.LookAtPlayer ();

			Vector2 target = new Vector2 (player.position.x, rb2d.position.y);
			Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, speed * Time.fixedDeltaTime);
			rb2d.MovePosition(newPos);

		}
		if (Vector2.Distance (player.position, rb2d.position) <= shootRange) {
			animator.SetTrigger ("Attack");
		}

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.ResetTrigger ("Attack");
	}

}
