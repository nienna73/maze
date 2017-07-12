using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMaze : MonoBehaviour {
	[System.Serializable]
	public class Cell {

		public bool visited;
		public GameObject north; //1
		public GameObject east;  //2 
		public GameObject west;  //3
		public GameObject south; //4
	}

	public GameObject wall;
	public GameObject player;
	public GameObject endPoint;
	public GameObject floor;
	private int xSize;
	private int ySize;
	private int initialSize = 2;
	public float wallLength = 1.0f;
	private Vector3 initialPos;
	private GameObject wallHolder;
	private Cell[] cells;
	private int currentCell = 0;
	private int totalCells = 0;
	private int visitedCells = 0;
	private bool startedBuilding = false;
	private int currentNeighbour = 0;
	private List<int> lastCells = new List<int>();
	private int backingUp = 0;
	private int wallToBreak = 0;
	private List<GameObject> wallChildren = new List<GameObject> ();
	private float startValx = 1.5f;
	private float startValy = 1.0f;

	public static InfiniteMaze control;


	// Use this for initialization
	void Start () {
		if (control == null) {
			control = this;
			xSize = initialSize - 1;
			ySize = initialSize - 1;
		} else {
			Destroy (this);
		}
		CreateWalls ();
		
	}

	void CreateWalls() {

		xSize += 1;
		ySize += 1;

		wallLength = 1.0f;
		currentCell = 0;
		totalCells = 0;
		visitedCells = 0;
		startedBuilding = false;
		currentNeighbour = 0;
		lastCells.Clear ();
		backingUp = 0;
		wallToBreak = 0;

		wallHolder = new GameObject ();
		wallHolder.name = "Maze";


		initialPos = new Vector3 (wallLength, 0.0f, wallLength);
		Vector3 myPos = initialPos;
		Vector3 endPos;
		Vector3 startPos;
		GameObject tempWall;
		GameObject playerObject;

		//For x axis
		for (int i = 0; i < ySize; i++) {
			for (int j = 0; j <= xSize; j++) {
				myPos = new Vector3 (initialPos.x + (j * wallLength) - wallLength / 2, 0.0f, initialPos.z + (i * wallLength) - wallLength / 2);
				tempWall = Instantiate (wall, myPos, Quaternion.identity) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
				wallChildren.Add (tempWall);
			}
		}

		//For y axis
		for (int i = 0; i <= ySize; i++) {
			for (int j = 0; j < xSize; j++) {
				myPos = new Vector3 (initialPos.x + (j * wallLength), 0.0f, initialPos.z + (i * wallLength) - wallLength);
				tempWall = Instantiate (wall, myPos, Quaternion.Euler(0.0f, 90.0f, 0.0f)) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
				wallChildren.Add (tempWall);
			}
		}
	

		floor.transform.localScale = new Vector3 (xSize, 0.25f, ySize);
		floor.transform.position = new Vector3 (startValx, 0, startValy);
		myPos = new Vector3 (1.5f, 0, 1);
		startPos = new Vector3 (1, 0, 0.5f);
		endPos = new Vector3 (xSize, 0, ySize-0.5f);
		playerObject = Instantiate (player, startPos, Quaternion.identity);
		playerObject = Instantiate (endPoint, endPos, Quaternion.identity);

		startValx += 0.5f;
		startValy += 0.5f;

		CreateCells ();

	}

	void CreateCells() {
		lastCells = new List<int> ();
		lastCells.Clear ();
		totalCells = xSize * ySize;
		GameObject[] allWalls;
		int children = wallHolder.transform.childCount;
		allWalls = new GameObject[children];
		cells = new Cell[xSize * ySize];
		int eastWestProcess = 0;
		int childProcess = 0;
		int termCount = 0;


		//Gets all children
		for (int i = 0; i < children; i++) {
			allWalls [i] = wallHolder.transform.GetChild (i).gameObject;
		}


		//Assigns walls to the cells
		for (int cellProcess = 0; cellProcess < cells.Length; cellProcess++) {

			if (termCount == xSize) {
				eastWestProcess ++;
				termCount = 0;
			}

			cells [cellProcess] = new Cell ();
			cells [cellProcess].east = allWalls [eastWestProcess];
			cells[cellProcess].south = allWalls[childProcess+(xSize+1)*ySize];

			eastWestProcess++;

			termCount++;
			childProcess++;
			cells [cellProcess].west = allWalls [eastWestProcess];
			cells [cellProcess].north = allWalls [(childProcess + (xSize + 1) * ySize) + xSize - 1];

		}


		CreateMaze ();
		// GetStart ();
		// GetEnd ();


	}


	void CreateMaze() {
		// totalCells = xSize * ySize;

		while (visitedCells < totalCells) {
			if (startedBuilding) {
				GiveMeNeighbour ();
				if (cells [currentNeighbour].visited == false && cells [currentCell].visited == true) {
					BreakWall ();
					cells [currentNeighbour].visited = true;
					visitedCells++;
					lastCells.Add (currentCell);
					currentCell = currentNeighbour;

					if (lastCells.Count > 0) {
						backingUp = lastCells.Count - 1;

					}
				}


			}

			else {
				currentCell = Random.Range (0, totalCells);
				cells [currentCell].visited = true;
				visitedCells++;
				startedBuilding = true;

			}
				
		}
			

			
	}

	void BreakWall() {

		switch (wallToBreak) {
		case 1 : Destroy (cells [currentCell].north); break;
		case 2 : Destroy (cells [currentCell].east); break;
		case 3 : Destroy (cells [currentCell].west); break;
		case 4 : Destroy (cells [currentCell].south); break;
		}

	}

	void GiveMeNeighbour () {
		
		int length = 0;
		int[] neighbours = new int[4];
		int[] connectingWall = new int[4];
		int check = 0;
		check = ((currentCell + 1) / xSize);
		check -= 1;
		check *= xSize;
		check += xSize;


		//west
		if (currentCell + 1 < totalCells && (currentCell + 1) != check) {
			if (cells [currentCell + 1].visited == false) {
				neighbours [length] = currentCell + 1;
				connectingWall [length] = 3;
				length++;
			}
		}

		//east
		if (currentCell - 1 >= 0 && (currentCell) != check) {
			if (cells [currentCell - 1].visited == false) {
				neighbours [length] = currentCell - 1;
				connectingWall [length] = 2;
				length++;
			}
		}

		//north
		if (currentCell + xSize < totalCells) {
			if (cells [currentCell + xSize].visited == false) {
				neighbours [length] = currentCell + xSize;
				connectingWall [length] = 1;
				length++;
			}
		}

		//south
		if (currentCell - xSize >= 0) {
			if (cells [currentCell - xSize].visited == false) {
				neighbours [length] = currentCell - xSize;
				connectingWall [length] = 4;
				length++;
			}
		}
			
		if (length != 0) {
			int chosenOne = Random.Range (0, length);
			currentNeighbour = neighbours [chosenOne];
			wallToBreak = connectingWall [chosenOne];
		} else {
			if (backingUp > 0) {
				currentCell = lastCells [backingUp];
				backingUp--;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("End")) {
			LoadLevel ();
		}

	}

	void LoadLevel() {
		CreateWalls ();
	}

	public void Destroy() {
		for (int i = wallChildren.Count - 1; i >= 0; --i) {
			Destroy (wallChildren [i]);
		}
		wallChildren.Clear ();
		Destroy (wallHolder);
		CreateWalls ();
	}

	public int GetxSize(){
		return xSize;
	}

	public int GetySize(){
		return ySize;
	}


}
