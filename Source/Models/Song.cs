using System;
using System.ComponentModel;
using System.Drawing;

public class Song : INotifyPropertyChanged
{
    private string title;
    private string[] artists;
    private string album;
    private string[] genres;
    private TimeSpan duration;
    private string filePath;
    private Image albumArt;
    
    public event PropertyChangedEventHandler PropertyChanged;

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string[] Artists
    {
        get => artists;
        set
        {
            if (artists != value)
            {
                artists = value;
                OnPropertyChanged(nameof(Artists));
            }
        }
    }

    public string Album
    {
        get => album;
        set
        {
            if (album != value)
            {
                album = value;
                OnPropertyChanged(nameof(Album));
            }
        }
    }

    public string[] Genres
    {
        get => genres;
        set
        {
            if (genres != value)
            {
                genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }
    }

    public TimeSpan Duration
    {
        get => duration;
        set
        {
            if (duration != value)
            {
                duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
    }

    public string FilePath
    {
        get => filePath;
        set
        {
            if (filePath != value)
            {
                filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
    }

    public Image AlbumArt
    {
        get => albumArt;
        set
        {
            if (albumArt != value)
            {
                albumArt = value;
                OnPropertyChanged(nameof(AlbumArt));
            }
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
