namespace BananaParty.BehaviorTree
{
    public abstract class ConditionNode : BehaviorNode
    {
        public override bool ReactiveEvaluation => true;
    }
}
