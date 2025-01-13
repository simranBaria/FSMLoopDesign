using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class FlipFoodCT : ConditionTask {

		public GameObject[] foods;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			foods = GameObject.FindGameObjectsWithTag("Food");
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// Loop through each food item and check if any need to be flipped
			foreach (GameObject food in foods) if (food.GetComponent<Food>().needToFlip) return true;
			return false;
		}
	}
}