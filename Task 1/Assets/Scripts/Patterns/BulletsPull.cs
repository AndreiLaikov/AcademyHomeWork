using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPull : Singleton<BulletsPull>
{
    [Serializable]
    public struct PrefabData
    {
        public string name;
        public GameObject prefab;
    }

    [SerializeField] private List<PrefabData> prefabDatas = null;

	private Pool[] pools;
    public int minCount = 5;

    private void Start()
    {
		pools = new Pool[prefabDatas.Count];
		Initialize();
    }

    private void Initialize()
	{
		for (int i = 0; i < prefabDatas.Count; i++)
		{
			pools[i] = new Pool();
			pools[i].poolName = prefabDatas[i].name;
			pools[i].Initialize(minCount, prefabDatas[i].prefab);
		}
	}

	public GameObject GetObject(string name, Vector3 position, Quaternion rotation)
	{
		GameObject result = null;
		if (pools != null)
		{
			for (int i = 0; i < pools.Length; i++)
			{
				if (string.Compare(pools[i].poolName, name) == 0)
				{
					result = pools[i].GetObject().gameObject;
					result.transform.position = position;
					result.transform.rotation = rotation;

					result.SetActive(true);
					return result;
				}
			}
		}
		return result;
	}
}
