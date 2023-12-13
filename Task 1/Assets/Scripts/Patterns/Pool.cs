using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
	public List<GameObject> objects;
	public string poolName;

	private void AddObject(GameObject bullet)
	{
		GameObject temp = GameObject.Instantiate(bullet.gameObject);
		objects.Add(temp);
		temp.SetActive(false);
	}

	public void Initialize(int count, GameObject bullet)
	{
		objects = new List<GameObject>();
		for (int i = 0; i < count; i++)
		{
			AddObject(bullet);
		}
	}

	public GameObject GetObject()
	{
		for (int i = 0; i < objects.Count; i++)
		{
			if (objects[i].gameObject.activeInHierarchy == false)
			{
				return objects[i];
			}
		}

		AddObject(objects[0]);
		return objects[objects.Count - 1];
	}
}