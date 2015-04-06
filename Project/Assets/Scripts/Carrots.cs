using UnityEngine;
using System.Collections;

public class Carrots : MonoBehaviour {

	public LocationEnum.Location location;
	public Boat boat;
	public GameObject carrotsSprite;

	public Vector3 nearside, neardock, farside, fardock;

	// Use this for initialization
	void Start () {
		location = LocationEnum.Location.NearDock;
		nearside = new Vector3 (-0.23f, -0.74f);
		farside = new Vector3 (-0.23f, 1f);
		neardock = new Vector3 (2.59f, -2.82f);
		fardock = new Vector3 (2.59f, 3.22f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("c")) {
			if(location == LocationEnum.Location.NearDock && boat.location == LocationEnum.Location.Nearside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Nearside;
				boat.cargo = Boat.Cargo.Carrots;
				carrotsSprite.transform.position = nearside;
			}
			else if(location == LocationEnum.Location.FarDock && boat.location == LocationEnum.Location.Farside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Farside;
				boat.cargo = Boat.Cargo.Carrots;
				carrotsSprite.transform.position = farside;
			}
			else if(location == LocationEnum.Location.Nearside) // Must be on boat
			{
				location = LocationEnum.Location.NearDock;
				boat.cargo = Boat.Cargo.Empty;
				carrotsSprite.transform.position = neardock;
			}
			else if(location == LocationEnum.Location.Farside) // Must be on boat
			{
				location = LocationEnum.Location.FarDock;
				boat.cargo = Boat.Cargo.Empty;
				carrotsSprite.transform.position = fardock;
			}
			else {} // Not able to move, so do nothing
		}
	}
}
