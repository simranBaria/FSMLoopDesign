using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class CookingAT : ActionTask {

		public float walkSpeed;
		public Transform cookingSpot, foodPosition;
		public GameObject foodPrefab;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Move to cooking spot
			if (agent.transform.position != cookingSpot.position) agent.transform.position = Vector3.MoveTowards(agent.transform.position, cookingSpot.position, walkSpeed * Time.deltaTime);
			// Put food on stove
			else
            {
				Object.Instantiate(foodPrefab, foodPosition);
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}