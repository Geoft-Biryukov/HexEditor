using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexEditor
{
    class ReadBytesOptions : INotifyPropertyChanged
    {
        #region File Info Category
        private const string fileInfoCategory = "Info";

        private string fileName = string.Empty;
        [Category(fileInfoCategory)]
        [ReadOnly(true)]
        public string FileName
        {
            get => fileName;
            set
            {
                Set(nameof(FileName), ref fileName, value);
            }
        }

        private string fileSize = "0";
        [Category(fileInfoCategory)]
        [ReadOnly(true)]
        public string FileSize
        {
            get => fileSize;
            set
            {
                Set(nameof(FileSize), ref fileSize, value);
            }
        }

        #endregion

        #region Read Category
        private const string readCategory = "Read";

        private long offset = 0;
        [Category(readCategory)]
        public long Offset
        {
            get => offset;
            set
            {
                Set(nameof(Offset), ref offset, Math.Min(value, maxBytesToRead));
            }
        }

        private long bytesToRead = 1024;
        [Category(readCategory)]
        public long BytesToRead
        {
            get => bytesToRead;
            set
            {

                Set(nameof(BytesToRead), ref bytesToRead, Math.Min(value, maxBytesToRead - offset));
            }
        }
        #endregion

        #region View Category
        private const string viewCategory = "View";

        private int bytesInRow = 20;
        [Category(viewCategory)]
        public int BytesInRow
        {
            get => bytesInRow;
            set
            {
                Set(nameof(BytesInRow), ref bytesInRow, value);
            }
        }
        #endregion

        private void Set<T>(string propertyName, ref T field, T value)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private long maxBytesToRead = 0;
        public void SetMaxBytes(long length)
        {
            maxBytesToRead = length;
        }

    }
}
