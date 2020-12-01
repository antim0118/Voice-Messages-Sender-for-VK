namespace VMVK
{
    public struct ConversationStruct
    {
        public string convName;
        public long Id;
        public ConversationStruct(string convName, long Id)
        {
            this.convName = convName;
            this.Id = Id;
        }
        public override string ToString() => convName;
    }
}
