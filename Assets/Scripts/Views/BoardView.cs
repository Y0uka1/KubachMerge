using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Views
{
    public class BoardView:AView
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Collider a;

        public Transform SpawnPosition => spawnPosition;
    }
}