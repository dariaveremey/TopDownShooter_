using TDS.Assets.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Assets.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            _stateMachine = Services.Container.Get<IGameStateMachine>();
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<GameState, string>("GameScene");
        }
    }
}