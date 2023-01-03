using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        private const string INITIAL = "Initial";



        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            ResgisterServices();
            _sceneLoader.Load(INITIAL, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            
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