using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class TraceErrorNode : BehaviorNode
    {
        private readonly string _message;

        public TraceErrorNode(string message)
        {
            _message = message;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Trace.TraceError(_message);

            return BehaviorNodeStatus.Success;
        }
    }
}
