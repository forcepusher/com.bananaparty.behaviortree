using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class TraceInfoNode : BehaviorNode
    {
        protected override string Name => "Trace Info Node";

        private readonly string _message;

        public TraceInfoNode(string message)
        {
            _message = message;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            Trace.TraceInformation(_message);
            return BehaviorNodeStatus.Success;
        }
    }
}
