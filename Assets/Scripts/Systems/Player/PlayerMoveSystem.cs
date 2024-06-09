using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace CubeECS
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<PlayerInputComponent, PlayerComponent>> _filter;
        private EcsPoolInject<PlayerComponent> _playerPool;
        private EcsPoolInject<PlayerInputComponent> _playerInputPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var playerComponent = ref _playerPool.Value.Get(entity);

                if (!playerComponent.IsPlayerActive)
                    return;

                ref var playerInputComponent = ref _playerInputPool.Value.Get(entity);

                playerComponent.PlayerRB.MovePosition(playerComponent.PlayerRB.position +
                                                      playerInputComponent.MoveInput * playerComponent.PlayerSpeed *
                                                      Time.fixedDeltaTime);
            }
        }
    }
}