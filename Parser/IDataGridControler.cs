//using Microsoft.VisualStudio.Tools.Applications.Runtime;

namespace Parser
{
    public interface IDataGridControler
    {
        public int Count { get; }
        void AddEntry(Entry entry);
        void RemoveEntry(Entry entry);
        void EditEntry(Entry a, Entry b);
    }
}
