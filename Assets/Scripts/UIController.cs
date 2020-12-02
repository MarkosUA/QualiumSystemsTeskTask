namespace Assets.Scripts
{
    public class UIController
    {
        private MovingObject _movingObject;

        public UIController(MovingObject movingObject)
        {
            _movingObject = movingObject;
        }

        public void OnPauseButtonClick(bool isPause)
        {
            if (isPause)
            {
                _movingObject.StopMoving();
            }
            else
            {
                _movingObject.MoveToWayPoint();

            }
        }
    }
}