using System.Collections.Generic;

namespace OrchardSkills.OrchardCore.OrchardCMS.HttpClients
{
    public class DndArchive<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int Count { get; set; }
    }
}