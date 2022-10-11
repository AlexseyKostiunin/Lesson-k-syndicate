using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            RegistrInputService();
        }

        private void RegistrInputService()
        {
            if (Application.isEditor)
                InputService = new StandalonelInputService();
            else
                InputService = new MobileInputService();
        }
    }
}
