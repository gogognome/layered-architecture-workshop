using System;

namespace LibraryConsoleApplication
{
    class User
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            User that = obj as User;
            return that != null && this.Id == that.Id;
        }
    }
}
