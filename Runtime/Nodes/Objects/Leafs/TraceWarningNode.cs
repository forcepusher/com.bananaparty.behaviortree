using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class TraceWarningNode : BehaviorNode
    {
        private readonly string _message;

        public TraceWarningNode(string message)
        {
            _message = message;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            Trace.TraceWarning(_message);
            return BehaviorNodeStatus.Success;
        }
    }
}
