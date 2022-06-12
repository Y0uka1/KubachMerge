using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Views
{
    public class BoardView:LinkableView<GameEntity>
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Transform battleCanvasPosition;

        public Transform BattleCanvasPosition => battleCanvasPosition;

        public Transform SpawnPosition => spawnPosition;
    }
}