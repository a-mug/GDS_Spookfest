using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Controls : MonoBehaviour
{
	// Variables to control player movement
	public float movementSpeed = 2.0f;
	public float mouseSensitivity = 5.0f;
	float forwardSpeed = 0f, sideSpeed = 0.0f;
	float verticalRotation = 0.0f;
	float verticalVelocity = 0.0f;

	// How much the Player can look up and down
	public float upDownRange = 60.0f;

	//public float jumpSpeed = 5f;

	////Variables for the torch
	//public Light playerLight;
	//bool lightOn = false, inOtherMenu = false;
	//public float lightIntensity = 2.5f;
	//public float lightDecreaseRate = 0.1f;
	//public AudioSource click;
	//public Slider slider;
	//int lightColourCycle = 0, resetNum = 0;
	//public AudioSource pickUpBattery;
	//public AudioSource scream;
	//public GameObject playerLightPivot;

	//public AudioSource youDiedSound;
	//public Image youDied;
	//bool playerDead;
	//public GameObject quitButton;

	//public AudioSource backgroundSound;

	// If the cursor is locked
	public bool cursorLocked = false;

	public Text onScreenText;
	public float raycast_distance;

	CharacterController characterController;

	// Use this for initialization
	void Start()
	{
		//playerDead = true;

		//Locks the cursor in place and makes it hidden
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		//Screen.lockCursor = true;

		characterController = GetComponent<CharacterController>();
		//playerLight.enabled = false;
		//InvokeRepeating("UpdateLight", 0, 0.01f);
	}

	//void PickUpBattery()
	//{
	//    pickUpBattery.Play();
	//    playerLight.intensity += 2f;
	//    if (playerLight.intensity > 2.5)
	//    {
	//        playerLight.intensity = 2.5f;
	//    }
	//    slider.value = playerLight.intensity;
	//}

	//void UpdateLight()
	//{
	//    if (lightOn)
	//    {
	//        if (playerLight.intensity > 0)
	//        {
	//            playerLight.intensity -= lightDecreaseRate;
	//            slider.value = playerLight.intensity;
	//        }
	//    }
	//}

	//void ToggleLight()
	//{
	//    if (lightOn)
	//    {
	//        playerLight.enabled = false;
	//    }
	//    else
	//    {
	//        playerLight.enabled = true;
	//    }
	//    lightOn = !lightOn;
	//    click.Play();
	//}

	//void TogglePause()
	//{
	//    if (cursorLocked == true)
	//    {
	//        Cursor.lockState = CursorLockMode.None;
	//        Cursor.visible = true;
	//        cursorLocked = false;
	//    }
	//    else if (cursorLocked == false)
	//    {
	//        Cursor.lockState = CursorLockMode.Locked;
	//        Cursor.visible = false;
	//        cursorLocked = true;
	//    }
	//}


	//void CycleLight()
	//{
	//    lightColourCycle++;
	//    if (lightColourCycle == 4)
	//    {
	//        lightColourCycle = resetNum;
	//    }

	//    switch (lightColourCycle)
	//    {
	//        case 0:
	//            playerLight.color = Color.white;
	//            break;
	//        case 1:
	//            playerLight.color = Color.red;
	//            break;
	//        case 2:
	//            playerLight.color = Color.green;
	//            break;
	//        case 3:
	//            playerLight.color = Color.blue;
	//            break;
	//    }
	//}

	//void DisableWhiteLight(bool tempBool)
	//{
	//    if (tempBool == false)
	//    {
	//        resetNum = 1;
	//        CycleLight();
	//    }
	//    else
	//    {
	//        resetNum = 0;
	//    }
	//}

	//void ToggleOtherMenu(bool tempBool)
	//{
	//    inOtherMenu = tempBool;
	//}

	//IEnumerator WaitBeforDeath()
	//{
	//    yield return new WaitForSeconds(5);
	//    playerDead = true;
	//    TogglePause();

	//    backgroundSound.Stop();
	//    youDiedSound.Play();
	//    youDied.enabled = true;

	//    youDied.GetComponent<CanvasRenderer>().SetAlpha(0);
	//    youDied.CrossFadeAlpha(1f, 2f, false);

	//    yield return new WaitForSeconds(5);
	//    quitButton.SetActive(true);
	//}

	//void Dead()
	//{
	//    StartCoroutine(WaitBeforDeath());
	//}

	//void Alive()
	//{
	//    playerDead = false;
	//}


	// Update is called once per frame
	void Update()
	{
		// For interacting with objects ingame
		if (cursorLocked == true)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((Screen.width / 2), (Screen.height / 2)));
			if (Physics.Raycast(ray.origin, ray.direction, out hit, raycast_distance))
			{
				if (hit.collider.gameObject.tag == "PickUp")
				{
					onScreenText.text = "Press LMB to pick up";
					if (Input.GetMouseButtonDown(0))
					{
						hit.collider.gameObject.SetActive(false);
						//PickUpBattery();
					}
				}
				else if (hit.collider.gameObject.tag == "Puzzle1Button")
				{
					onScreenText.text = "Press LMB to interact";
					if (Input.GetMouseButtonDown(0))
					{
						hit.collider.gameObject.SendMessage("toggle");
						//PickUpBattery();
					}
				}
				else if (hit.collider.gameObject.tag == "Note")
				{
					//onScreenText.text = "Press LMB to interact";
					if (Input.GetMouseButtonDown(0))
					{
						//ToggleOtherMenu(true);
						//onScreenText.text = "";
						//string tempObjectName = hit.collider.gameObject.name;
						//GameObject tempObject = GameObject.Find(tempObjectName);
						//tempObject.SendMessage("ToggleMenu");
					}
				}
				else
				{
					onScreenText.text = "";
				}

			}
			else
			{
				onScreenText.text = "";
			}


			//CameraRoatation
			float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);

			verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

			//Moves the camera and the player light
			Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
			//playerLight.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

			//Movement
			forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
			sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

			if (characterController.isGrounded)
			{
				verticalVelocity = 0;
			}
			else
			{
				verticalVelocity += Physics.gravity.y * Time.deltaTime * 2;
			}

			Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

			speed = transform.rotation * speed;

			characterController.Move(speed * Time.deltaTime);

			//if (Input.GetKeyDown(KeyCode.E))
			//{
			//    CycleLight();
			//}

			//if (Input.GetMouseButtonDown(1))
			//{
			//    ToggleLight();
			//}
		}

		//if (Input.GetKeyDown(KeyCode.Escape) & inOtherMenu == false & playerDead == false)
		//{
		//    TogglePause();
		//    GameObject tempPauseCanvas = GameObject.Find("PauseMenu");
		//    tempPauseCanvas.SendMessage("ToggleIsPaused");
		//}


	}
}
