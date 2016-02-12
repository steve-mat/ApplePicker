using UnityEngine;

public class Apple : MonoBehaviour {

	private static float MAXFALLPOINT = -18f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		DestroyAppleOnFall();

	}

	private void DestroyAppleOnFall() {

		if(this.transform.position.y < MAXFALLPOINT) {
			Destroy(this.gameObject);

			ApplePicker applePickerRef = GameObject.FindGameObjectWithTag("GM").GetComponent<ApplePicker>();
			applePickerRef.SubtractLife();
		}

		
		

	}
}
