namespace BananaParty.BehaviorTree
{
    public abstract class ActionNode : BehaviorNode
    {
        public override bool ReactiveEvaluation => false;
    }
}
