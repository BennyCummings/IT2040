
namespace RandomMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Random Music Playlist\n______________________");

        int playlistNum = 1;
        bool saveQuitOption = true;
        while(saveQuitOption){
            List<string> fileSongs = LoadSongs();
            int songAmount = fileSongs.Count();
            List<string> playlist = PlaylistMaker(fileSongs, songAmount);

            int num = 1;

            Console.WriteLine($"Playlist {playlistNum}:\n-------------");
            playlistNum++;
            foreach(string song in playlist){
                Console.WriteLine($"Song {num}: "+song);
                num++;
            }
            saveQuitOption = getSaveQuitOption(playlist);
        }
    }

    static int GetUserNumber(int songAmount){
        int number;
        while(true){
            Console.WriteLine("Enter number of songs to play:\n");
            
            try{
            number = int.Parse(Console.ReadLine()!);
            if(number < 1 || number > songAmount){
                Console.WriteLine($"ERROR: Input must be between 1 and {songAmount}");
                continue;
            }
            break;
            }catch(Exception error){
                Console.WriteLine("\nThe value inputed is invalid. Only numerical values allowed.");
                Console.WriteLine($"Error: {error.GetType().Name}\n");
            }
            
        }
        return number; 
    }

    static List<string> PlaylistMaker(List<string> songs, int songAmount){
        Random random = new Random();
        int number = GetUserNumber(songAmount);
        List<string> playlist = new List<string>();

        while(number > playlist.Count()){
            int randomNumber = random.Next(songAmount);
            if(!playlist.Contains(songs[randomNumber])){
                playlist.Add(songs[randomNumber]);
            }
        } 
        return playlist;

    }

    static List<string> LoadSongs(){
        List<string> fileSongs = new List<string>();

        string fullPath = Path.Join(".", "data", "songs.csv");

        using(StreamReader fileReader = new StreamReader(fullPath)){
            string headerData = fileReader.ReadLine()!;

            while(!fileReader.EndOfStream){
                string lineOfDate = fileReader.ReadLine()!;

                string[] songData = lineOfDate.Split(",");

                string songName = songData[0];
                string artistName = songData[1];
                
                fileSongs.Add($"{songName}: {artistName}");
            }
        }
        return fileSongs;
    }
    static void savePlaylist(List<string> playlist, string playlistName){
        using(StreamWriter fileWriter = new StreamWriter($"{playlistName}")){
            foreach(string song in playlist){
                string[] saveSplit = song.Split(": ");
                string songName = saveSplit[0];
                string artistName = saveSplit[1];
                

                fileWriter.WriteLine($"{songName},{artistName}");
            }
        }
    }
    static string getPlaylistName(){
        string playlistName;
        while (true){
            Console.WriteLine("\nEnter a name for your playlist file");
            playlistName = Console.ReadLine()!;
            if(playlistName == ""){
                Console.WriteLine("ERROR: Need to name playlist");
                continue;
            }
            else{
                if(!playlistName.Contains(".txt")){
                    playlistName = playlistName+".txt";
                }
                break;
            }
    }
    return playlistName;
    }
    static bool getSaveQuitOption(List <string> playlist){
        Console.WriteLine(@"Choose one of the following options
------------------------
1. Save playlist & Continue
2. Save Playlist & Quit
3. DON'T Save Playlist & Continue
4. DON'T Save Playlist & Quit

Enter Save Option:");
        
        while(true){
            int saveOption = 0;
            try{
                saveOption = int.Parse(Console.ReadLine()!);
                }
            catch(Exception){
                Console.WriteLine("ERROR: Please enter a number between 1 and 4");
            }
            string playlistName;
            if(saveOption == 1){
                playlistName = getPlaylistName();
                savePlaylist(playlist, playlistName);
                return true;
                }
                 if(saveOption == 2){
                playlistName = getPlaylistName();
                savePlaylist(playlist, playlistName);
                Console.WriteLine("EXITING PROGRAM...");
                return false;
                }
                if(saveOption == 3){
                    return true;
                }
                if(saveOption == 4){
                    Console.WriteLine("EXITING PROGRAM...");
                   return false; 
                }
                else{
                    Console.WriteLine("ERROR: Please enter a number between 1 and 4");
                    continue;  
                }
        }
    }
}