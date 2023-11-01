

namespace DatabasePostgres.Persistance.SqlRequest.NotesSqlRequest
{
    public class NotesSqlRequest
    {
        public string CreateTableNotes = "CREATE TABLE Notes(id SERIAL PRIMARY KEY,NickId TEXT UNIQUE,Title TEXT,Content TEXT,CreatedAt DATA);";

        public string NotesAdd = "INSERT INTO Notes(NickId,Titl,Content,CreatedAt)"
            + "VALUES(@NickId,@Titl,@Content,@CreatedAt);";

        public string ChangeNotes = "UPDATE Notes SET Title = @Title,Content = @Content WHERE NickId = @NickId;";

        public string DeleteNotes = "DELETE FROM Notes WHERE id = @id;";


    }
}
