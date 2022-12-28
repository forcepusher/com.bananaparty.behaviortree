using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class TraceErrorNode : BehaviorNode
    {
        protected override string Name => "Trace Error Node";

        private readonly string _message;

        public TraceErrorNode(string message)
        {
            _message = message;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            Trace.TraceError(_message);
            return BehaviorNodeStatus.Success;
        }
    }
}
