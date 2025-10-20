using AP.BTP.Domain.Interfaces;

namespace AP.BTP.Domain
{
    public class Tree: IDeletable
    {
        public int Id { get; set; }
        public required String Species { get; set; }
        public bool IsDeleted { get; set; }
    }
}
