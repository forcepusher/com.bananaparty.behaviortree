using System;

namespace BananaParty.BehaviorTree
{
    public class RandomSkipNode : DecoratorNode
    {
        private readonly float _skipChance;

        public RandomSkipNode(IBehaviorNode childNode, float skipChance = 0.5f) : base(childNode)
        {
            _skipChance = skipChance;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status == BehaviorNodeStatus.Idle)
            {
                bool shouldSkip = new Random().NextDouble() <= _skipChance;
                if (shouldSkip)
                    return BehaviorNodeStatus.Success;
            }

            return ChildNode.Execute(time);
        }
    }
}
