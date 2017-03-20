using System;

namespace LibraryConsoleApplication
{
    class BorrowedBook
    {
        public long Id { get; set; }
        public long BookID { get; set; }
        public long UserID { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
