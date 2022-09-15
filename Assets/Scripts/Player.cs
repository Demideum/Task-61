using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPointPlayer;

    public Vector3 Die()
    {
        return _spawnPointPlayer;
    }
}
