using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace CubeECS
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorldInject _world;
        private EcsPoolInject<PlayerComponent> _playerPool;
        private EcsPoolInject<PlayerInputComponent> _playerInputPool;
        private EcsCustomInject<GameData> _gameData;

        public void Init(IEcsSystems systems)
        {
            var playerEntity = _world.Value.NewEntity();

            _playerPool.Value.Add(playerEntity);
            ref var playerComponent = ref _playerPool.Value.Get(playerEntity);

            var playerGO = _gameData.Value.Player;
            playerComponent.IsPlayerActive = false;
            playerComponent.PlayerSpeed = _gameData.Value.Configuration.PlayerSpeed;
            playerComponent.PlayerTransform = playerGO.transform;
            playerComponent.PlayerRB = playerGO.GetComponent<Rigidbody2D>();
            playerComponent.PlayerAudioSource = playerGO.GetComponentInChildren<AudioSource>();
            playerComponent.PlayerAnimator = playerGO.GetComponentInChildren<Animator>();

            _playerInputPool.Value.Add(playerEntity);
        }
    }
}