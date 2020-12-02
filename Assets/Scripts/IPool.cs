using UnityEngine;

public interface IPool
{
    void Push(GameObject gameObject);
    GameObject Pull();
}