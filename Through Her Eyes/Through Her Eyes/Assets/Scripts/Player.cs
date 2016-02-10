using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Range(1, 3)]
	public int moveSpeed = 2;
	CharacterController cc;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;

	// Use this for initialization
	void Awake () {
        cc = GetComponent<CharacterController>();

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
		float mX = Input.GetAxis ("Mouse X");
		float mY = Input.GetAxis ("Mouse Y");

		//Debug.Log (mX + ", " + mY);
		//transform.Rotate ((transform.up * mX + -transform.right * mY) * 2f);
		//transform.Rotate (transform.right * mY * 2f);
		cc.SimpleMove((transform.forward * v + transform.right * h) * moveSpeed * 1.5f);

		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}

	void FixedUpdate()
	{
		//Debug.DrawLine(transform.position, Camera.main.transform.forward, Color.blue, true);
	}
}
