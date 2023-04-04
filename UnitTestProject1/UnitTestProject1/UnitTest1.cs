using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NoteApp.Tests
{
    [TestClass]
    public class NoteAppTests
    {
        [TestMethod]
        public void Test_AddNoteCommandHandler()
        {
            // Arrange
            var notes = new List<string>();
            var command = new AddNoteCommand { Title = "Test Note", Body = "This is a test note." };
            var handler = new AddNoteCommandHandler(notes);

            // Act
            handler.Handle(command);

            // Assert
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual("Test Note: This is a test note.", notes[0]);
        }

        [TestMethod]
        public void Test_GetNotesQueryHandler_NoNotes()
        {
            // Arrange
            var notes = new List<string>();
            var handler = new GetNotesQueryHandler(notes);

            // Act
            var result = handler.Handle();

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Test_GetNotesQueryHandler_WithNotes()
        {
            // Arrange
            var notes = new List<string> { "Note 1: This is note 1.", "Note 2: This is note 2." };
            var handler = new GetNotesQueryHandler(notes);

            // Act
            var result = handler.Handle();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Note 1: This is note 1.", result[0]);
            Assert.AreEqual("Note 2: This is note 2.", result[1]);
        }
    }
}
