using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingMedia
{
    public abstract class StreamingPlatform : IPlayer
    {
        protected MediaFile playing;
        protected MediaFile[] files;
        public bool isPlaying;
        public int totalTacks;

        public StreamingPlatform()
        {

        
        }
        public virtual void Play(int MediaIndex)
        {
            playing = files[MediaIndex];
            playing.position = MediaIndex + 1;
            isPlaying = true;
            ShowPlaying();
        }
        public virtual void StartPlaying()
        {

            if (playing is null)// Controlla se c'è già una brano che stata suonando 
            {
                // SongIndex  = new Random().Next(0, songs.Length - 1); // prendi un brano a caso
                playing = files[0]; // Prelevo il brano dall'array  con l'indice creato
                playing.position = 0;
            }
            ShowPlaying();
        }
        public virtual void ShowPlaying()
        {
            Console.ForegroundColor = ConsoleColor.Black; // Cambio il colore di sfondo della riga a video
            Console.BackgroundColor = playing.Color; // Cambio il colore del  test  della riga a video
            Console.WriteLine($"Playing now : - Postion: {playing.position} - {playing.title.ToUpper()}");
            Console.ResetColor();

        }
        public virtual void Stop()
        {
            playing.state = MediaFile.MediaState.Stopped;
        }
        public virtual void Pause()
        {
            playing.state = MediaFile.MediaState.Paused;
        }
        public virtual void Rate()
        {
            playing.rated = true;
        }
        public virtual void Forward()
        {
            int next = Array.FindIndex(files, i => i.title == playing.title);
            int track = Utility.Carousel(files.Length, next + 1);
            Play(track);
        }
        public virtual void Backward()
        {
            int next = Array.FindIndex(files, i => i.title == playing.title);
            int track = Utility.Carousel(files.Length, next - 1);
            Play(track);
        }
        public virtual void MediaList()
        {
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1} -   {files[i].title} ");
            }
        }

        protected class MediaFile
        {
            public int id;
            public string title;
            public MediaState state = MediaState.Paused;
            public bool rated;
            public int position;
            public ConsoleColor Color;

            public MediaFile()
            {
            }

            public enum MediaState
            {
                Playing,
                Paused,
                Stopped
            }

        }
        protected class Music : MediaFile
        {
            public Music()
            {

            }
        }
        protected class Video : MediaFile
        {
            public Video()
            {

            }
        }

    }

    static class Utility
    {
        static Utility()
        {
        }

        public static bool CheckInput(int ArrayLenght, int Input)
        {
            if (Input >= 1 && Input <= ArrayLenght)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" brano nuemero {Input} non presente nel catalogo.");
                Console.ResetColor();
                return false;
            }
        }
        public static int Carousel(int ArrayLenght, int Input)
        {
            int result;

            if (Input < 0)
            {
                result = ArrayLenght - 1;
            }
            else if (Input > ArrayLenght - 1)
            {
                return result = 0;
            }
            else
            {
                result = Input;
            }
            return result;

        }

    }
}
