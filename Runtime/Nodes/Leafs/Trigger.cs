using BananaParty.BehaviorTree;

namespace BananaParty.DungeonCrawler
{
    public class Trigger : Node
    {
        private bool _state;

        public override NodeStatus OnExecute(float deltaTime)
        {
            if (_state)
            {
                _state = false;
                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }

        public void Actuate()
        {
            _state = true;
        }

        public void Clear()
        {
            _state = false;
        }
    }
}
