using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CarController : MonoBehaviour {

	public Text Score;
	public GameObject Buttons;
	public GameObject DeathScreen;
	public GameObject ReloadPanel;
	public BarLine BenzinBar;
	public GameObject BottomBar;
	public GameObject[] Ways;	
	public Transform WheelPos1;
	public Transform WheelPos2;
	public Transform RoofPos;
	public float CheckRad;
	public LayerMask WhatIsGround;
	public float JumpValue;
	public WheelJoint2D Frontwheel;
	public WheelJoint2D Backwheel;
	JointMotor2D MotorFront;
	JointMotor2D MotorBack;
	public float SpeedF;
	public float SpeedB;
	public float TorqueF;
	public float TorqueB;
	public bool TractionFront = true;
	public bool TractionBack = true;
	public float CarRotationSpeed;

	private bool isGrounded, isOrGrounded;
	private bool isDeath = false;
	private bool isPressed;
	private int currentType = 1;
	private int currentCnt = 1;
	private Random rnd = new Random();
	private int scoreVal;


    private void Start()
    {
		if (PlayerPrefs.HasKey("JumpyBagScore"))
		{
			scoreVal = PlayerPrefs.GetInt("JumpyBagScore");
		}
	}


    void Update () {

		bool isGrounded1 = Physics2D.OverlapCircle(WheelPos1.position, CheckRad, WhatIsGround);
		bool isGrounded2 = Physics2D.OverlapCircle(WheelPos2.position, CheckRad, WhatIsGround);
		bool isCrashed = Physics2D.OverlapCircle(RoofPos.position, 0.25f, WhatIsGround);
		isOrGrounded = isGrounded1 || isGrounded2;
		isGrounded = isGrounded1 && isGrounded2;

		// Car Controlling
		if (Input.GetAxisRaw("Vertical") < 0)
		{
			if (TractionFront)
			{
				MotorFront.motorSpeed = SpeedB * -1;
				MotorFront.maxMotorTorque = TorqueB;
				Frontwheel.motor = MotorFront;
			}

			if (TractionBack)
			{
				MotorBack.motorSpeed = SpeedB * -1;
				MotorBack.maxMotorTorque = TorqueB;
				Backwheel.motor = MotorBack;
			}
		}
		else
		{
			if (TractionFront)
			{
				MotorFront.motorSpeed = SpeedF * -1;
				MotorFront.maxMotorTorque = TorqueF;
				Frontwheel.motor = MotorFront;
			}

			if (TractionBack)
			{
				MotorBack.motorSpeed = SpeedF * -1;
				MotorBack.maxMotorTorque = TorqueF;
				Backwheel.motor = MotorBack;
			}
		}
		if (Input.GetAxisRaw ("Horizontal") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (CarRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

		}
		if (isOrGrounded && Input.GetKey(KeyCode.Space) && !isPressed)
		{		
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpValue);
			isPressed = true;
		}
		else if (!isOrGrounded)
			isPressed = false;


		// Check score
		if (isOrGrounded)
        {
			int number = WheelControl.getNumHit();
			if (number > currentCnt)
			{
				currentCnt = number;
				Score.text = "" + currentCnt;
				CreateWay();
			}
		}

		
		// Check for loss
		if (transform.position.y < -8 && !isDeath || isCrashed && !isDeath)
        {			
			isDeath = true;
			DeathScreen.GetComponent<Animator>().Play("DeathScreenFade");			
			Invoke("ReloadPanelOpen", 1f);
		}
	}


	// If you lose, the panel opens
	private void ReloadPanelOpen()
	{
		BottomBar.GetComponent<Animator>().Play("BottomBarHide");
		Score.GetComponent<Animator>().Play("ScoreHide");
		Buttons.GetComponent<Animator>().Play("ButtonsHide");
		ReloadPanel.SetActive(true);

		// Update score save
		if (currentCnt > scoreVal)
        {
			PlayerPrefs.SetInt("JumpyBagScore", currentCnt);
			PlayerPrefs.Save();
			scoreVal = currentCnt;
		}
	}


	// Create new track in runtime
	private void CreateWay()
	{
		int toCnt = currentCnt + 1;
		int value = rnd.Next(0, 5);
		if (currentType == 4)
			value = rnd.Next(0, 1);
		else
		{
			while (value == currentType)
				value = rnd.Next(0, 5);
		}

		GameObject mWay = Instantiate(Ways[value], new Vector3(-6.666f + (currentCnt) * 37, -0.29f, -0.1f), Quaternion.identity);
		mWay.name = "way" + toCnt;
		currentType = value;
	}


	// Refueling a car
	public void AddBenzin()
    {
		BenzinBar.AddBenzin();
	}


	// Fuel ran out
	public void FuelOut()
    {
		isDeath = true;
		DeathScreen.GetComponent<Animator>().Play("DeathScreenFade");
		Invoke("ReloadPanelOpen", 1f);
	}


	// Сlick on the screen - Jump
	public void ButtonTapScreen()
    {
		if(isOrGrounded && !isPressed)
		{
			//GetComponent<Rigidbody2D>().velocity = transform.up * 10f;
			//GetComponent<Rigidbody2D>().velocity = Vector2.up * 10f;			
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpValue);
			isPressed = true;
		}
		else if (!isOrGrounded)
			isPressed = false;
	}


	// Сlick on the screen button - Turn Left
	public void ButtonLeftScreen()
	{
		GetComponent<Rigidbody2D>().AddTorque(CarRotationSpeed * 6);
	}


	// Сlick on the screen button - Turn Right
	public void ButtonRightScreen()
	{
		GetComponent<Rigidbody2D>().AddTorque(CarRotationSpeed * -6);
	}
}
