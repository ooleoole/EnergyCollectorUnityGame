using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]

public class UITextMS : MonoBehaviour 
{
	private MotherShip motherShip;
	public int msEnergy;
	public int energyNeeded;

	// Use this for initialization
	void Awake () 
	{
		motherShip = GameObject.Find ("MotherShip").GetComponent<MotherShip>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		msEnergy = motherShip.collectedEnergy;
		energyNeeded = motherShip.neededEnergy;

		GetComponent<Text>().text = msEnergy + " / " + energyNeeded;
	}
}
