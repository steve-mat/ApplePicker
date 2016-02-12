using UnityEngine;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;

	private float speed = 5.0f;

	private float leftAndRightEdge = 20.0f;

	private float chanceToChangeDirections = 1.0f;

	private float secondsBetweenAppleDrops = 1.0f;

	Vector3 appleTreePos = Vector3.zero;

	private float rand = 0f;

	

	// Use this for initialization
	void Start () {

		InvokeRepeating("DropApple", 3.0f, secondsBetweenAppleDrops);

	}
	
	// Update is called once per frame
	void Update () {

		appleTreePos = MoveAppleTree();
		CheckDirectionChange(appleTreePos);
		rand = Random.value * 100f;


	}

	void FixedUpdate() {

		CheckRandomDirectionChange();

	}


	private Vector3 MoveAppleTree() {

		Vector3 appleTreePos = this.transform.position;
		appleTreePos.x = appleTreePos.x + (speed * Time.deltaTime);
		this.transform.position = appleTreePos;
		return appleTreePos;

	}

	private void CheckDirectionChange(Vector3 vect) {

		if(vect.x < -leftAndRightEdge || vect.x > leftAndRightEdge) {
			speed = -speed;
		}

	}

	private void CheckRandomDirectionChange() {

		if(rand < chanceToChangeDirections) {
			speed = -speed;
		}

	}

	private void DropApple() {

		GameObject apple = Instantiate(applePrefab);
		apple.transform.position = this.transform.position;

	}

	
}
