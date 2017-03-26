using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour 
{
	public int collectedEnergy = 0;
	public int neededEnergy;

	public GameObject[] energy;
	public int totalEnergy;

	public float difficultyPercentage = 0.5f;
	
	private PlayerInventory playerInventory;

	private Animator _anim;

	public float restartDelay = 3f;
	private float _restartTimer;
	
	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
		energy = GameObject.FindGameObjectsWithTag("Energy");
		totalEnergy = energy.Length;
		neededEnergy = Mathf.RoundToInt (totalEnergy * difficultyPercentage);
		_anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
	}

	void Update()
	{
		if(totalEnergy < neededEnergy || collectedEnergy == neededEnergy)
		{
			//print ("Game Over!");
			_anim.SetTrigger("IsGameOver");

			_restartTimer+= Time.deltaTime;

			if(_restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Take collected count and add it to the energy of the reactor, then reset the players collected energy to zero
			if(playerInventory.collectedEnergy != 0)
			{
				collectedEnergy += playerInventory.collectedEnergy;
				playerInventory.collectedEnergy = 0;
			}
			//Need ten to win the game.
			//if(collectedEnergy == neededEnergy)
			//{
				//print ("You win!");
				//anim.SetTrigger("IsGameOver");
			//}
			
		}
	}
}
