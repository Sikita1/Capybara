using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _containerEnemy;
    [SerializeField] private int _capacityEnemy;

    private List<Enemy> _poolEnemy = new List<Enemy>();

    protected void Initialize(Enemy[] prefabs)
    {
        for (int i = 0; i < _capacityEnemy; i++)
        {
            Enemy spawned = Instantiate(prefabs[i], _containerEnemy.transform);
            spawned.gameObject.SetActive(false);

            _poolEnemy.Add(spawned);
        }
    }

    protected bool TryGetRandomObject(out Enemy result)
    {
        List<Enemy> gameObjects = _poolEnemy.
                                  Where(enemy => enemy.gameObject.activeSelf == false).
                                  ToList();

        if (gameObjects.Count == 0)
        {
            result = null;
            return false;
        }

        result = gameObjects[Random.Range(0, gameObjects.Count)];

        return true;
    }
}
