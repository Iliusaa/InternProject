using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;

namespace Stackspire.SceneFlow
{
    public sealed class SceneNavigator : MonoBehaviour
    {
        [SerializeField] private bool enableGameOverDebugKey;
        [SerializeField] private KeyCode gameOverDebugKey = KeyCode.G;

        private void Update()
        {
            if (enableGameOverDebugKey && IsGameOverDebugKeyPressed())
            {
                LoadGameOver();
            }
        }

        private bool IsGameOverDebugKeyPressed()
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current == null)
            {
                return false;
            }

            return gameOverDebugKey == KeyCode.G && Keyboard.current.gKey.wasPressedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKeyDown(gameOverDebugKey);
#else
            return false;
#endif
        }

        public void LoadMainMenu()
        {
            LoadScene("MainMenu");
        }

        public void LoadClassSelect()
        {
            LoadScene("ClassSelect");
        }

        public void LoadGame()
        {
            LoadScene("Game");
        }

        public void LoadGameOver()
        {
            LoadScene("GameOver");
        }

        private static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
