using System;

namespace BananaParty.BehaviorTree
{
    public class RandomSkip : Decorator
    {
        private readonly float _skipChance;

        public RandomSkip(INode childNode, float skipChance = 0.5f) : base(childNode)
        {
            _skipChance = skipChance;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            if (Status == NodeStatus.Idle)
            {
                bool shouldSkip = new Random().NextDouble() <= _skipChance;
                if (shouldSkip)
                    return NodeStatus.Success;
            }

            return ChildNode.Execute(deltaTime);
        }
    }
}
