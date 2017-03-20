using System;

namespace LibraryConsoleApplication
{
    class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } 
        public string Author { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Book that = obj as Book;
            return that != null && this.Id == that.Id;
        }
    }
}
