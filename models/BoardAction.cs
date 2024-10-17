namespace PlayerDotNet.models
{
    public class BoardAction
    {
        public UInt32 Src = 0;
        public UInt32 Dest = 0;
        public UInt32 Amount = 0;
        public Guid Uuid = new Guid();
        public UInt32 Player = 0;
        public Progress Progress = new Progress();
    }
}
