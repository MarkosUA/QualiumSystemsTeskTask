using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PauseButtonScript
    {
        public delegate void onPauseButtonClick(bool create);
        public event onPauseButtonClick onPauseButtonClickAction;

        private bool _IsPause;

        public PauseButtonScript(Button button)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            _IsPause = !_IsPause;

            onPauseButtonClickAction?.Invoke(_IsPause);
        }
    }
}