using UnityEngine;
using System.Collections;

public class Lights_Corridor : MonoBehaviour 
{
	public AudioSource off_sound;
	public Light[] lightArray;
	public float time_between_turn_off;
	int i;
	bool first_collision;

	// Use this for initialization
	void Start () 
	{
		first_collision = false;
		i = 0;
		//InvokeRepeating("UpdateLight", 0, 0.01f);

		//Invoke
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" & first_collision == false) 
		{
			InvokeRepeating("turnOffLight", 0.0f, time_between_turn_off);
			first_collision = true;
		}
	}

	void actualTurnOff()
	{
		//lightArray [i].enabled = false;
		Destroy(lightArray [i]);
		i++;
	}

	void turnOffLight()
	{
		if (i < 5) 
		{
			Invoke ("actualTurnOff", 0.1f);
			off_sound.Play();

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
