using UnityEngine;
using System.Collections;

public class Puzzle1Button : MonoBehaviour 
{
	public GameObject puzzle1;
	Puzzle parent_puzzle_script;

	public int[] xy;

	public int x;
	public int y;

	bool active;
	Color this_color;

	// Use this for initialization
	void Start () 
	{
		parent_puzzle_script = puzzle1.GetComponent<Puzzle> ();
		active = false;
		this.GetComponent<MeshRenderer> ().material.color = Color.red;
	}

	void toggle()
	{

		if (active == false) 
		{
			this_color = Color.green;
			active = true;
		} 
		else 
		{
			this_color = Color.red;
			active = false;
		}

		this.GetComponent<MeshRenderer> ().material.color = this_color;

		parent_puzzle_script.ChangeArrayPosition (x, y);
		//puzzle1.SendMessage ("changeArrayPosition", xy);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
