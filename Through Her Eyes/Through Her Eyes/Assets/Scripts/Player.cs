using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Range(1, 3)]
	public int moveSpeed = 2;
	CharacterController cc;
	RaycastHit hit;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;

	GameObject grabbedObject;

	// Use this for initialization
	void Awake () {
        cc = GetComponent<CharacterController>();
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


		// Hovers and grabs objects
		if (grabbedObject == null) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
			if (Physics.Raycast (ray, out hit, 1)) {
				GameObject go = hit.collider.gameObject;
				if (go.GetComponent<Grabable> () != null) {
					go.GetComponent<Grabable> ().Hover ();
					if (Input.GetMouseButtonDown (0)) {
						grabbedObject = go;
						grabbedObject.GetComponent<Collider>().enabled = false;
						grabbedObject.GetComponent<Rigidbody>().useGravity = false;
						grabbedObject.GetComponent<Rigidbody> ().Sleep ();
					}
				}
			}
		} else {
			//grabbedObject.transform.parent = GameObject.Find("GrabbedObject").transform;
			
			//GameObject.Find("GrabbedObject").transform.position = Camera.main.transform.position;
			grabbedObject.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * .6f);
			if (Input.GetMouseButtonDown (0)) {
				Vector3 pos = Camera.main.transform.position + (Camera.main.transform.forward * .2f);
				grabbedObject.transform.position = pos;
				grabbedObject.GetComponent<Rigidbody> ().WakeUp();
				grabbedObject.GetComponent<Rigidbody>().useGravity = true;
				grabbedObject.GetComponent<Collider>().enabled = true;
				grabbedObject = null;
			}
		}
	}

	void FixedUpdate()
	{
		//Debug.DrawLine(transform.position, Camera.main.transform.forward, Color.blue, true);
	}
}
