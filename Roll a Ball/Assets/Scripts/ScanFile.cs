using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanFile : MonoBehaviour {
	public Texture2D t2d;
	public Color[] field;
	[SerializeField]
	GameObject Cube;
	// Use this for initialization
	void Start () {
		t2d = Resources.Load ("pixelmap") as Texture2D;
		field = new Color[t2d.height * t2d.width];
		for (int i = 0; i < t2d.width; i++) {
			for (int j = 0; j < t2d.height; j++) {
				field [(t2d.height * i) + j] = t2d.GetPixel (i, j);
			}
		}
		MakeWalls (t2d.height, t2d.width);
		PutObjects (t2d.height,t2d.width);
	}
	Color getColor(int r,int g,int b){
		float rr = r;
		float gg = g;
		float bb = b;
	return new Color (rr / 255.0f, gg / 255.0f, bb / 255.0f,1);

	}
	void MakeWalls(int ht,int wh){
		GameObject wl= Resources.Load ("Wall") as GameObject;
		for (int i = 0; i < ht + 2; i++) {
			Instantiate (wl, new Vector3 (0, 0, i), Quaternion.Euler (Vector3.zero));
		}
		for (int i = 0; i < ht + 2; i++) {
			Instantiate (wl, new Vector3 (wh+1, 0, i), Quaternion.Euler (Vector3.zero));
		}
		for (int i = 1; i < wh + 1; i++) {
			Instantiate (wl, new Vector3 (i, 0, 0), Quaternion.Euler (Vector3.zero));
		}
		for (int i = 1; i < wh + 1; i++) {
			Instantiate (wl, new Vector3 (i, 0, ht+1), Quaternion.Euler (Vector3.zero));
		}
		GameObject terra = Resources.Load ("Plane") as GameObject;
		GameObject trn = Instantiate (terra, new Vector3 (wh/2, -0.5f, ht/2),Quaternion.Euler(Vector3.zero));
		Transform trnsfrm = trn.GetComponent<Transform> ();


			trnsfrm.localScale = new Vector3 (0.1f*wh+0.1f, 0.5f, 0.1f*ht+0.1f);
		if (wh%2==1)
			trnsfrm.position = trnsfrm.position + new Vector3 (0.5f, 0, 0);
		if (ht%2==1)
			trnsfrm.position = trnsfrm.position + new Vector3 (0, 0, 0.5f);
		
	}
	void PutObjects(int ht,int wh){
		GameObject Player = Resources.Load ("Player") as GameObject;
		GameObject Collectible = Resources.Load ("Collectible") as GameObject;
		Cube= Resources.Load ("Cube") as GameObject;
		for (int i = 0; i < wh; i++) {
			for (int j = 0; j < ht; j++) {
				if (field [ht * i + j] == Color.black) {
					Instantiate (Cube, new Vector3 (i + 1, 0, j + 1), Quaternion.Euler (Vector3.zero));
				}
				if (field [ht * i + j] == Color.white) {
					Instantiate (Player, new Vector3 (i + 1, 0, j + 1), Quaternion.Euler (Vector3.zero));

				}
				if (field [ht * i + j] == getColor(255,255,0)) {
					Instantiate (Collectible, new Vector3 (i + 1, 0, j + 1), Quaternion.Euler (Vector3.zero));

				}
			}
		}

	}
	// Update is called once per frame
	void Update () {
	}
}
