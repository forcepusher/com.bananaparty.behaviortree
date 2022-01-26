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

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Trace.TraceWarning(_message);

            return BehaviorNodeStatus.Success;
        }
    }
}
