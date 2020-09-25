using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ObservableCollection
{
    class ImageFactory
    {
        public static int count = 0;
        private static readonly Images _myactualdata = new Images();
        public static Images MyImages
        {
            get
            {
                return _myactualdata;
            }
        }
        public class Images : ObservableCollection<ImageData>
        {
            public Images()
            {
                this.Add(new ImageData(@"Resources\Images\1.jpg"));
                this.Add(new ImageData(@"Resources\Images\2.jpg"));
                this.Add(new ImageData(@"Resources\Images\3.jpg"));
            }
        }

        public class ImageData : INotifyPropertyChanged
        {
            private String _sImageName = "";
            public ImageData(string sImageName)
            {
                ImageFactory.count++;
                ImageName = sImageName;
            }

            public String ImageName
            {
                get
                {
                    return _sImageName;
                }
                set
                {
                    _sImageName = value;
                    NotifyPropertyChanged(ImageName);
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected void NotifyPropertyChanged(String sProp)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));

            }
        }
    }
}