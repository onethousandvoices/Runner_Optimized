using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        private int _progress;

        private const float _step = 6f;
        private int _currentIndex;
        private float _lastZ = 30f;
        private const int _levelsLength = 1024 * 1024;

        [SerializeField, Range(1, 100), Tooltip("Это здоровье игрока, не перепутай")]
        private int Health = 3;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private Transform[] _levels;
        [SerializeField, Space]
        private Text _text;

        public static GameManager Self { get; private set; }

        private void Awake()
        {
            Self = this;
        }

		private void Update()
		{
            if (_player.position.y <= -1f) SetDamage();
        }

		public void SetDamage()
        {
            Health -= 1;

            Debug.Log("Current health: " + Health);

            if (Health > 0) return;
            Debug.Log("---Игрок погиб!---");
            UnityEditor.EditorApplication.isPaused = true;
        }

        public void UpdateLevel()
        {
            _progress++;
            _text.text = _progress.ToString();

            _lastZ += _step;
            for(int i = 0; i < _levelsLength; i++)
            {
                Vector3 position = _levels[_currentIndex].position;
                position.z = _lastZ;
                _levels[_currentIndex].position = position;
            }

            _currentIndex++;
            if (_currentIndex >= _levels.Length)
            {
                _currentIndex = 0;
            }
	    }
    }
}