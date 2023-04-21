using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingMedia
{
    internal interface IPlayer
    {
        public void Play(int SongId);
        public void ShowPlaying();
        public void StartPlaying();
        public void Stop();
        public void Pause();
        public void Rate();
        public void Forward();
        public void Backward();
        public void MediaList();
    }
}
