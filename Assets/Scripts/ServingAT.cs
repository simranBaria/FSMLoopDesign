using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ServingAT : ActionTask {

		public float walkSpeed;
		public Transform cookingSpot, counterSpot;
		public GameObject[] foods;
		bool movingToStove = true, pickingUpFood = false, movingToCounter = false;
		public GameObject moneyText;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			movingToStove = true;
			pickingUpFood = false;
			movingToCounter = false;
			foods = GameObject.FindGameObjectsWithTag("Food");
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Move to cooking spot
			if (agent.transform.position != cookingSpot.position && movingToStove) agent.transform.position = Vector3.MoveTowards(agent.transform.position, cookingSpot.position, walkSpeed * Time.deltaTime);
			if (agent.transform.position == cookingSpot.position)
			{
				movingToStove = false;
				pickingUpFood = true;
			}

			// Bring food to counter
			if (pickingUpFood)
			{
				foreach (GameObject food in foods) if (food.GetComponent<Food>().done) food.GetComponent<Food>().serving = true;
				pickingUpFood = false;
				movingToCounter = true;
			}
			if (movingToCounter) agent.transform.position = Vector3.MoveTowards(agent.transform.position, counterSpot.position, walkSpeed * Time.deltaTime);

			// Serve the food
			if (agent.transform.position == counterSpot.position)
            {
				foreach (GameObject food in foods)
				{
					if (food.GetComponent<Food>().serving)
					{
						food.GetComponent<Food>().Serve();
						moneyText.GetComponent<Money>().money += 5;
					}
				}
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