using UnityEngine;
using System.Collections;

public class EnergyPickup : MonoBehaviour 
{
	PlayerInventory playerInventory;
    
	void Start()
	{
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerInventory.collectedEnergy ++;
			gameObject.SetActive(false);
		}
	}
}