using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            ResgisterServices();
        }

        private void ResgisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        public void Exit()
        {

        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandalonelInputService();
            else
                return new MobileInputService();
        }
    }
}