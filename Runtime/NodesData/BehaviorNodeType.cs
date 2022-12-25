namespace BananaParty.BehaviorTree
{
    public enum BehaviorNodeType
    {
        Leaf,
        Chain,
        Decorator,
        Sequence,
        Selector,
        ParallelSequence,
        ParallelSelector,
        ParallelFirstComplete
    }
}
