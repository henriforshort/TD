using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoSingleton <TowerManager>
{
	public List<TowerType> towers;

	//Storage
	GameObject towerBuildPreview;

	[System.Serializable] public struct TowerType
	{
		public GameObject prefab;
		public int price;
		public float range;
		public float reloadingTime;
		public float damage;
		public float bulletSpeed;
		public GameObject bulletPrefab;
		public Vector3 bulletSpawnPoint;
		public Button buildButton;
		public Button cancelButton;
	}

	public enum towerName {standard, fast};

	void Start () {
		for (int i=0; i<towers.Count; i++) {
			int j = i;
			towers[i].buildButton.onClick.AddListener(delegate {CreateTower(j); });
			towers[i].cancelButton.onClick.AddListener(delegate {CancelTower(j); });
		}
	}

	void CreateTower (int towerNumber) {
		SetCancelButton (true, towerNumber);
		towerBuildPreview = Instantiate (towers[towerNumber].prefab, transform.position, Quaternion.identity, transform);
		towerBuildPreview.GetComponent<TowerBuild> ().StartPurchase ();
	}

	void CancelTower (int towerNumber) {
		SetCancelButton (false, towerNumber);
		Destroy (towerBuildPreview);
	}

	public void SetCancelButton (bool mode, int towerNumber)
	{
		towers[towerNumber].buildButton.gameObject.SetActive (!mode);
	}
}
 