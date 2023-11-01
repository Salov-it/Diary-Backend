using NotesServices.Application.Dto;

namespace DatabasePostgres.Persistance.Interface
{
    public interface INotesRepositoryPostgres
    {
        Task<CreateNotesDto> CreateTableNotes(CreateNotesDto createContent);
    }
}
