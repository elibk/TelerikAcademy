namespace H03FileSystemRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        private string name;
        private IList<File> files = new List<File>();
        private IList<Folder> subFolders = new List<Folder>();

        public Folder(string name = "NewFolder") 
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public IList<File> Files
        {
            get
            {
                return this.files;
            }

            private set
            {
                this.files = value;
            }
        }

        public IList<Folder> SubFolders
        {
            get
            {
                return this.subFolders;
            }

            private set
            {
                this.subFolders = value;
            }
        }

        private long CalculateFilseSizes()
        {
            long size = 0;

            for (int i = 0; i < this.files.Count; i++)
            {
                size += this.files[i].Size;
            }

            return size;
        }

        private long CalculateFoldersSizes()
        {
            long size = 0;

            for (int i = 0; i < this.subFolders.Count; i++)
            {
                size += this.subFolders[i].CalculateSize();
            }

            return size;
        }

        public long CalculateSize()
        {
            long size = this.CalculateFilseSizes() + this.CalculateFoldersSizes();

            return size;
        }
    }
}
