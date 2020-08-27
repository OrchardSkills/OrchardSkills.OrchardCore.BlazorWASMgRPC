using System.Threading.Tasks;

namespace OrchardSkills.OrchardCore.OrchardCMS.HttpClients
{
    public interface IDnDClient
    {
        Task<DndArchive<DnDClassArchiveItem>> GetAllClassesAsync();
        Task<DndClass> GetClassAsync(string id);
    }
}