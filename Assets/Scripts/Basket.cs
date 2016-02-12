using UnityEngine;

public class Basket : MonoBehaviour {

	public bool addScore;
	// Use this for initialization
	void Start () {
		addScore = false;
	}
	
	// Update is called once per frame
	void Update () {

		MoveBasket();
		ChangeScoreBool();
	}

	public void MoveBasket() {

		Vector3 mousePos2D = Input.mousePosition;

		mousePos2D.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Apple") {
			addScore = true;
		    Destroy(other.gameObject);
		}

	}

	void ChangeScoreBool() {
		if(addScore == true) {
			addScore = false;
		}
	}

}
