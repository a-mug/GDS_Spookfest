using UnityEngine;
using System.Collections;
//u suck andrew

public class Puzzle : MonoBehaviour 
{
	int[,] correct_array;
	int[,] input_array;
	bool correct;

	public GameObject door;
	public float door_speed;
	public float door_move_dist;
	float door_counter;

	float start_x;
	float start_y;
	float start_z;

	// Use this for initialization
	void Start () 
	{
		door_counter = 0.0f;
		correct = false;

		start_x = this.transform.position.x;
		start_y = this.transform.position.y;
		start_z = this.transform.position.z;

		correct_array = new int[4,4]
		{
			{1, 0, 0, 0},
			{0, 0, 0, 0},
			{0, 0, 0, 0},
			{0, 0, 0, 0}
		};

//		{
//			{0, 1, 0, 1},
//			{0, 1, 0, 0},
//			{1, 0, 1, 0},
//			{0, 1, 1, 1}
//		};

		input_array = new int[4, 4];

		for (int i = 0; i < 4; i++) 
		{
			for (int j = 0; j < 4; j++) 
			{
				input_array [i, j] = 0;
			}
		}
	}

	public void ChangeArrayPosition(int x, int y)
	{
		if (correct == false) 
		{
			if (input_array [y, x] == 1) 
			{
				input_array [y, x] = 0;
			} 
			else 
			{
				input_array [y, x] = 1;
			}

			correct = CheckArrays ();
		}
	}

	bool CheckArrays()
	{
		for (int i = 0; i < 4; i++) 
		{
			for (int j = 0; j < 4; j++) 
			{
				if (correct_array [i, j] != input_array [i, j]) 
				{
					return false;
				}
			}
		}

		Debug.Log ("Puzzle1 Complete");
		return true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (correct == true && door_counter < door_move_dist) 
		{

			this.transform.localPosition = new Vector3 (start_x, start_y,  start_z + door_counter);
			door_counter += door_speed;
		}
	}
}
