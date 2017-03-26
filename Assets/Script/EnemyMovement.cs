using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
	
	private MotherShip motherShip;
	private PlayerInventory playerInventory;
	
	
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		motherShip = GameObject.Find("MotherShip").GetComponent<MotherShip>();
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
	}
	
	
	void Update ()
	{

		// Set the destination of the nav mesh agent to the player.
		if(motherShip.collectedEnergy != motherShip.neededEnergy)
		{
			nav.SetDestination (player.position);
		}
		else
		{
			// Disable the nav mesh agent.
			nav.enabled = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Reduce the total amount of energy available and take collected energy from player
			motherShip.totalEnergy -= playerInventory.collectedEnergy;
			playerInventory.collectedEnergy = 0;

		}
	}
}