using NotesMauiBlazorWasm.Common.Interfaces;
using NotesMauiBlazorWasm.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NotesMauiBlazorWasm.Common.Services
{
    public class NotesService
    {
        private readonly IStorageService _storageService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public NotesService(IStorageService storageService) 
        { 
            _storageService = storageService;
            _jsonSerializerOptions = new();
        }
        public async Task<IEnumerable<Note>> GetAllNotesAsync() 
        {
            var serializedNotes = await _storageService.GetAsync(AppConstants.StorageKeys.Notes);            
            if (!string.IsNullOrWhiteSpace(serializedNotes))
            {
                var notes = JsonSerializer.Deserialize<IEnumerable<Note>>(serializedNotes, _jsonSerializerOptions);
                return notes!;
            }
            return Enumerable.Empty<Note>();
        }

        public async Task AddNoteAsync(Note note)
        {            
            if (note.Id != Guid.Empty)
            {               
                note.Id = Guid.NewGuid();
                note.CreatedOn = DateTime.Now;
                //note.ModifiedOn = DateTime.Now;
                var notes = (await GetAllNotesAsync()).ToList();

                notes.Add(note);     
                
                await SaveNotesAsync(notes);
            }
        }

        public async Task UpdateNoteAsync(Note note)
        {
            if (note.Id != Guid.Empty)
            {
                var notes = await GetAllNotesAsync();
                var noteToUpdate = notes.FirstOrDefault(n => n.Id == note.Id);

                if (noteToUpdate is not null)
                {
                    noteToUpdate.Title = note.Title;
                    noteToUpdate.Description = note.Description;
                    noteToUpdate.ModifiedOn = DateTime.Now;

                    await SaveNotesAsync(notes);
                }
            }
        }

        public async Task DeleteNoteAsyn(Guid id)
        {
            if (id != Guid.Empty)
            {
                var notes = (await GetAllNotesAsync()).ToList();
                var noteToDelete = notes.FirstOrDefault(n => n.Id == id);

                if (noteToDelete is not null)
                {
                    notes.Remove(noteToDelete);

                    await SaveNotesAsync(notes);
                }
            }
        }

        public async Task<Note?> GetNoteAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                var notes = await GetAllNotesAsync();
                return notes.FirstOrDefault(n => n.Id == id);
            }
            return null;
        }

        public async Task SaveNotesAsync(IEnumerable<Note> notes)
        {
            var serializedNotes = JsonSerializer.Serialize(notes, _jsonSerializerOptions);
            await _storageService.SaveAsync(AppConstants.StorageKeys.Notes, serializedNotes);
        }
    }
}
