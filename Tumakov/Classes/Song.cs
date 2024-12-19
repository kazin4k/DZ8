using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov.Classes
{
    class Song
    {
        private string name;
        private string author;
        private Song prev;

        public Song()
        {
            this.name = string.Empty;
            this.author = string.Empty;
            this.prev = null;
        }

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = null;
        }

        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Песня: {name}, Исполнитель: {author}");
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashName = name?.GetHashCode() ?? 0;
            int hashAuthor = author?.GetHashCode() ?? 0;
            return hashName ^ hashAuthor;
        }
    }
}
