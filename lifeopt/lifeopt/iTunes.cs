using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTunesLib;

namespace lifeopt
{
    class iTunes
    {
        public iTunesAppClass tunes = new iTunesAppClass();
        public IITSourceCollection src;
        public IITPlaylistCollection playlists;
        public IITTrackCollection songs;
        public iTunes()
        {

        }
        public void loadCmbPlaylists()
        {
            playlists = tunes.LibrarySource.Playlists;

            //    dataGridView1.Columns.Add("artist", "artist");

            //    dataGridView1.Columns.Add("song", "song");
            //    dataGridView1.Columns.Add("album", "album");
        }
    }
}
