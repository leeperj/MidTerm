
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace LibraryMidtermReFactored
{
    public class Prompts
    {

        public static void Intro()
        {
            Console.WriteLine("Welcome to the Online Library Catalog");
        }

        public static void AskToSearchReturnOrAdd()
        {

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Check an item out.");
            Console.WriteLine("2. Search inventory");
            Console.WriteLine("3. Return an item.");
            Console.WriteLine("4. Donate to the Library.");
            Console.WriteLine("5. Quit.");
            string searchOrAddResonse = Console.ReadLine().ToLower();
            if (searchOrAddResonse == "1")
            {
                GoToCheckOut();
            }
         
            else if (searchOrAddResonse == "2")
            {
                MovieBookorMusic();
            }
            else if (searchOrAddResonse == "3")
            {
                WhichMediaToCheckIn();
            }
            else if(searchOrAddResonse == "4")
            {
                AskWhichMediaToAdd();
            }
            else if(searchOrAddResonse == "5")
                {
               Console.WriteLine("Have a nice day!");
               return;
            }

            else
            {
                Console.WriteLine("Invalid response");
                AskToSearchReturnOrAdd();
            }


        }

        public static void AskWhichMediaToAdd()
        {
            List<Book> bookInfo = BookMethods.BookTxtToList();
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();

            Console.WriteLine("Which media would you like to add to the database?\n1.Book\n2.Movie\n3.Music");
            string mediaToAddResponse = Console.ReadLine().ToLower();
            if (mediaToAddResponse == "1")
            {
                BookMethods.AddToBookList(bookInfo);
                Console.WriteLine("Thank you for donating! We appreciate it!");
                AskToSearchReturnOrAdd();
            }

            else if (mediaToAddResponse == "2")
            {
                MovieMethods.AddToMovieList(movieInfo);
                Console.WriteLine("Thank you for donating! We appreciate it!");
                AskToSearchReturnOrAdd();
            }

            else if (mediaToAddResponse == "3")
            {
                MusicMethods.AddToMusicList(musicInfo);
                Console.WriteLine("Thank you for donating! We appreciate it!");
                AskToSearchReturnOrAdd();
            }

            else
            {
                Console.WriteLine("Invalid response");
                AskWhichMediaToAdd();
            }
        }

        public static void MovieBookorMusic()
        {
            Console.WriteLine("What would you like to search for?\n1. Book\n2. Movie\n3. Music\n4. Quit");
            string userMediaPreference = Console.ReadLine().ToLower();

            if (userMediaPreference == "1")
            {
                List<Book> bookInfo = BookMethods.BookTxtToList();
                Console.WriteLine("We have a lot of books.");
                Console.WriteLine("1. Search by title.\n2. Search by author\n3. Full List\n4. Quit");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    BookMethods.SearchBookTitle(bookInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    BookMethods.SearchBookAuthor(bookInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    BookMethods.PrintBookList(bookInfo);
                    AskToSearchOrCheckOut();
                }
                else if(userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }

            }
            else if (userMediaPreference == "2")
            {
                List<Movie> movieInfo = MovieMethods.MovieTxtToList();
                Console.WriteLine("We have a lot of movies.\n1. Search by title.\n2. Search by director.\n3. Full List\n4. Quit.");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    MovieMethods.SearchMovieTitle(movieInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    MovieMethods.SearchMovieDirector(movieInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    MovieMethods.PrintMovieList(movieInfo);
                    AskToSearchOrCheckOut();
                }
                else if (userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }
            }
            else if (userMediaPreference == "3")
            {
                List<Music> musicInfo = MusicMethods.MusicTxtToList();
                Console.WriteLine("We have a lot of music albums!\n1. Search by Title.\n2. Search by Artist.\n3. Full List.\n4. Quit.");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    MusicMethods.SearchMusicTitle(musicInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    MusicMethods.SearchMusicArtist(musicInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    MusicMethods.PrintMusicList(musicInfo);
                    AskToSearchOrCheckOut();
                }
                else if(userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }
                      

            }
            else if (userMediaPreference == "4")
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That was not a valid response.");
                MovieBookorMusic();
            }

            
        }

        public static void AskToSearchOrCheckOut()
        {
            Console.WriteLine("Did you find what you're looking for? Y/N");
            string searchAgainResponse = Console.ReadLine().ToLower();
            if (searchAgainResponse == "y" || searchAgainResponse == "yes")
            {
                GoToCheckOut();
            }
            else if (searchAgainResponse == "n" || searchAgainResponse == "no")
            {
                MovieBookorMusic();
            }         
            else
            {
                Console.WriteLine("Invalid Response");
                AskToSearchOrCheckOut();
            }


        }

        public static void GoToCheckOut()
        {
            bool validate;
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();
            List<Book> bookInfo = BookMethods.BookTxtToList();
            {
                string whichMediaType = WhichMediaToCheckOut();
                if (whichMediaType == "1")
                {
                    validate = AskForBookTitleToCheckOut(bookInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

                else if (whichMediaType == "2")
                {
                    validate = AskForMovieTitleToCheckOut(movieInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

                else
                {
                    validate = AskForMusicTitleToCheckOut(musicInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

            }
        }

        public static string WhichMediaToCheckOut() //Gets called in the GoToCheckOut Method
        {
            Console.WriteLine("Great! What are you checking out today?\n1. Book\n2. Movie\n3. Music Album");
            string userCheckOutType = Console.ReadLine().ToLower();
            if (userCheckOutType == "1" || userCheckOutType == "2" || userCheckOutType == "3")
            {
                return userCheckOutType;
            }
            else
            {
                Console.WriteLine("Invalid Response");
                WhichMediaToCheckOut();
            }
            return userCheckOutType;

        }
        public static string WhichMediaToCheckIn() 
        {
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();
            List<Book> bookInfo = BookMethods.BookTxtToList();

            Console.WriteLine("Great! and what are you checking in today?\n1.Book\n2.Movie\n3.Music Album");
            string userCheckInType = Console.ReadLine().ToLower();
            if (userCheckInType == "1")
            {
                CheckInBook(bookInfo);
            }
            else if (userCheckInType == "2")
            {
                CheckInMovie(movieInfo);
            }
            else if (userCheckInType == "3")
            {
                CheckInMusic(musicInfo);
            }
            else
            {
                Console.WriteLine("Invalid Response");
                WhichMediaToCheckIn();
            }
            return userCheckInType;

        }
        public static bool AskForBookTitleToCheckOut(List<Book> bookList) //returns fall if there is no match
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);
            bool ans = true;
            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine().ToLower();
            foreach (var book in bookList)
            {
                if (book.Title.ToLower().Contains(userTitleToCheckOut))
                {
                    Console.WriteLine($"Would you like to check out {book.Title} by {book.Author}? \nY/N");
                    string userResponse = Console.ReadLine().ToLower();
                    if (userResponse == "y")
                    {
                        if (book.Status == "in")
                        {
                            Console.WriteLine($"You have checked out {book.Title} until {answer}");
                            string originalLineOfInfo = book.Title + '|' + book.Year + '|' + book.Genre + '|' + book.MediaType + '|' + book.Status + '|' + book.Pages + '|' + book.Author + '|' + book.Format;
                            book.Status = $"checked out until {answer}";
                            string lineOfInfo = book.Title + '|' + book.Year + '|' + book.Genre + '|' + book.MediaType + '|' + book.Status + '|' + book.Pages + '|' + book.Author + '|' + book.Format;
                            WriteToBookTextFileCheckOut(bookList, lineOfInfo, originalLineOfInfo);
                        }
                        else
                        {
                            Console.WriteLine("This book is aleady checked out");
                            Console.WriteLine("Would you like to check it in?");
                            string ans1 = Console.ReadLine();
                            string originalLineOfInfo = book.Title + '|' + book.Year + '|' + book.Genre + '|' + book.MediaType + '|' + book.Status + '|' + book.Pages + '|' + book.Author + '|' + book.Format;
                            book.Status = "in";
                            string lineOfInfo = book.Title + '|' + book.Year + '|' + book.Genre + '|' + book.MediaType + '|' + book.Status + '|' + book.Pages + '|' + book.Author + '|' + book.Format;
                            if (ans1 == "y")
                            {
                                WriteToBookFileCheckIn(bookList, lineOfInfo, originalLineOfInfo);

                            }
                        }
                    }


                }

            }
            return ans;
        }
        public static void WriteToBookFileCheckIn(List<Book> bookList, string line1, string line2)
        {
            var oldLines = File.ReadAllLines("../../../BookTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach (string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach (string j in newNewLines)
            {
                count1++;
                if (j == line2)
                {
                    newNewLines[count1 - 1] = line1;
                }
            }
            File.WriteAllLines("../../../BookTextFile.txt", newNewLines);
        }
        public static void WriteToBookTextFileCheckOut(List<Book> bookList, string line1, string line2) 
        {
            //take in the wanted line as a string array, make it a single string, rewrite the entire text file
            var oldLines = File.ReadAllLines("../../../BookTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach(string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach(string j in newNewLines)
            {
                count1++;
                if(j == line2)
                {
                    newNewLines[count1-1] = line1;
                }
            }
            File.WriteAllLines("../../../BookTextFile.txt", newNewLines);
        }
        public static bool AskForMovieTitleToCheckOut(List<Movie> movieList) //returns fall if there is no match
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);
            bool ans = true;
            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine().ToLower();
            foreach (var movie in movieList)
            {
                if (movie.Title.ToLower().Contains(userTitleToCheckOut))
                {
                    Console.WriteLine($"Would you like to check out {movie.Title} by {movie.Director}? \nY/N");
                    string userResponse = Console.ReadLine().ToLower();
                    if (userResponse == "y")
                    {
                        if (movie.Status == "in")
                        {
                            Console.WriteLine($"You have checked out {movie.Title} until {answer}");
                            string originalLineOfInfo = movie.Title + '|' + movie.Year + '|' + movie.Genre + '|' + movie.MediaType + '|' + movie.Status + '|' + movie.Rating + '|' + movie.Director + '|' + movie.Format;
                            movie.Status = $"checked out until {answer}";
                            string lineOfInfo = movie.Title + '|' + movie.Year + '|' + movie.Genre + '|' + movie.MediaType + '|' + movie.Status + '|' + movie.Rating + '|' + movie.Director + '|' + movie.Format;
                            WriteToMovieTextFileCheckOut(movieList, lineOfInfo, originalLineOfInfo);
                        }
                        else
                        {
                            Console.WriteLine("This book is aleady checked out");
                            Console.WriteLine("Would you like to check it in?");
                            string ans1 = Console.ReadLine();
                            string originalLineOfInfo = movie.Title + '|' + movie.Year + '|' + movie.Genre + '|' + movie.MediaType + '|' + movie.Status + '|' + movie.Rating + '|' + movie.Director + '|' + movie.Format;
                            movie.Status = "in";
                            string lineOfInfo = movie.Title + '|' + movie.Year + '|' + movie.Genre + '|' + movie.MediaType + '|' + movie.Status + '|' + movie.Rating + '|' + movie.Director + '|' + movie.Format;
                            if (ans1 == "y")
                            {
                                WriteToMovieFileCheckIn(movieList, lineOfInfo, originalLineOfInfo);

                            }
                        }
                    }


                }

            }
            return ans;
        }
        public static void WriteToMovieFileCheckIn(List<Movie> movieList, string line1, string line2)
        {
            var oldLines = File.ReadAllLines("../../../MovieTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach (string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach (string j in newNewLines)
            {
                count1++;
                if (j == line2)
                {
                    newNewLines[count1 - 1] = line1;
                }
            }
            File.WriteAllLines("../../../MovieTextFile.txt", newNewLines);
        }
        public static void WriteToMovieTextFileCheckOut(List<Movie> movieList, string line1, string line2)
        {
            //take in the wanted line as a string array, make it a single string, rewrite the entire text file
            var oldLines = File.ReadAllLines("../../../MovieTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach (string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach (string j in newNewLines)
            {
                count1++;
                if (j == line2)
                {
                    newNewLines[count1 - 1] = line1;
                }
            }
            File.WriteAllLines("../../../MovieTextFile.txt", newNewLines);
        }

        public static bool AskForMusicTitleToCheckOut(List<Music> musicList) //returns fall if there is no match
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);
            bool ans = true;
            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine().ToLower();
            foreach (var music in musicList)
            {
                if (music.Title.ToLower().Contains(userTitleToCheckOut))
                {
                    Console.WriteLine($"Would you like to check out {music.Title} by {music.Artist}? \nY/N");
                    string userResponse = Console.ReadLine().ToLower();
                    if (userResponse == "y")
                    {
                        if (music.Status == "in")
                        {
                            Console.WriteLine($"You have checked out {music.Title} until {answer}");
                            string originalLineOfInfo = music.Title + '|' + music.Year + '|' + music.Genre + '|' + music.MediaType + '|' + music.Status + '|' + music.Rating + '|' + music.Artist + '|' + music.Format;
                            music.Status = $"checked out until {answer}";
                            string lineOfInfo = music.Title + '|' + music.Year + '|' + music.Genre + '|' + music.MediaType + '|' + music.Status + '|' + music.Rating + '|' + music.Artist + '|' + music.Format;
                            WriteToMusicTextFileCheckOut(musicList, lineOfInfo, originalLineOfInfo);
                        }
                        else
                        {
                            Console.WriteLine("This book is aleady checked out");
                            Console.WriteLine("Would you like to check it in?");
                            string ans1 = Console.ReadLine();
                            string originalLineOfInfo = music.Title + '|' + music.Year + '|' + music.Genre + '|' + music.MediaType + '|' + music.Status + '|' + music.Rating + '|' + music.Artist + '|' + music.Format;
                            music.Status = "in";
                            string lineOfInfo = music.Title + '|' + music.Year + '|' + music.Genre + '|' + music.MediaType + '|' + music.Status + '|' + music.Rating + '|' + music.Artist + '|' + music.Format;
                            if (ans1 == "y")
                            {
                                WriteToMusicFileCheckIn(musicList, lineOfInfo, originalLineOfInfo);

                            }
                        }
                    }


                }

            }
            return ans;
        }
        public static void WriteToMusicFileCheckIn(List<Music> musicList, string line1, string line2)
        {
            var oldLines = File.ReadAllLines("../../../MusicTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach (string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach (string j in newNewLines)
            {
                count1++;
                if (j == line2)
                {
                    newNewLines[count1 - 1] = line1;
                }
            }
            File.WriteAllLines("../../../MusicTextFile.txt", newNewLines);
        }
        public static void WriteToMusicTextFileCheckOut(List<Music> musicList, string line1, string line2)
        {
            //take in the wanted line as a string array, make it a single string, rewrite the entire text file
            var oldLines = File.ReadAllLines("../../../MusicTextFile.txt");
            var newLines = oldLines.Where(line => line != line1);//issue is that with this line we are rewriting everything that isnt the updated line
            var newNewLines = new string[oldLines.Length];
            int count = 0;
            foreach (string i in newLines)
            {
                newNewLines[count] = i;
                count++;
            }
            int count1 = 0;
            foreach (string j in newNewLines)
            {
                count1++;
                if (j == line2)
                {
                    newNewLines[count1 - 1] = line1;
                }
            }
            File.WriteAllLines("../../../MusicTextFile.txt", newNewLines);
        }
        public static bool CheckInBook(List<Book> bookList)
        {
            Console.WriteLine("What title are you checking in?");
            string userTitleToCheckIn = Console.ReadLine().ToLower();
            foreach (var book in bookList)
            {
                if (book.Title.ToLower().Contains(userTitleToCheckIn))
                {
                    Console.WriteLine($"Are you checking in {book.Title}? Y/N");
                    string userYesNo = Console.ReadLine().ToLower();
                    if (userYesNo == "y" || userYesNo == "yes")
                    {
                        Console.WriteLine($"Thank you for bringing back {book.Title}.");
                        book.Status.Replace($"check out until {null}", "in");
                        return true;
                    }
                    else if (userYesNo == "n" || userYesNo == "no")
                    {
                        Console.WriteLine("Ok, thanks anyway.");
                        return false;
                    }
                    return true;

                }
            }
            return false;

        }
        public static bool CheckInMovie(List<Movie> movieList)
        {
            Console.WriteLine("What title are you checking in?");
            string userTitleToCheckIn = Console.ReadLine().ToLower();
            foreach (var movie in movieList)
            {
                if (movie.Title.ToLower().Contains(userTitleToCheckIn))
                {
                    Console.WriteLine($"Are you checking in {movie.Title}? Y/N");
                    string userYesNo = Console.ReadLine().ToLower();
                    if (userYesNo == "y" || userYesNo == "yes")
                    {
                        Console.WriteLine($"Thank you for bringing back {movie.Title}.");
                        movie.Status.Replace($"check out until {null}", "in");
                        return true;
                    }
                    else if (userYesNo == "n" || userYesNo == "no")
                    {
                        Console.WriteLine("Ok, thanks anyway.");
                        return false;
                    }
                    return true;

                }
            }
            return false;

        }
        public static bool CheckInMusic(List<Music> musicList)
        {
            Console.WriteLine("What title are you checking in?");
            string userTitleToCheckIn = Console.ReadLine().ToLower();
            foreach (var music in musicList)
            {
                if (music.Title.ToLower().Contains(userTitleToCheckIn))
                {
                    Console.WriteLine($"Are you checking in {music.Title}? Y/N");
                    string userYesNo = Console.ReadLine().ToLower();
                    if (userYesNo == "y" || userYesNo == "yes")
                    {
                        Console.WriteLine($"Thank you for bringing back {music.Title}.");
                        music.Status.Replace($"check out until {null}", "in");
                        return true;
                    }
                    else if(userYesNo == "n" || userYesNo == "no")
                    {
                        Console.WriteLine("Ok, thanks anyway.");
                        return false;
                    }
                    return true;

                }   
            }
            return false;

        }

        public static void NotInStockPrompt()
        {
            Console.WriteLine("We do not have that in stock");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Would you like to retry another title, go back to search, or exit?\n1.Retry\n2.Search\n3.Exit");
                int userNotInStockResponse = int.Parse(Console.ReadLine());
                if (userNotInStockResponse == 1)
                {
                    GoToCheckOut();
                }

                else if (userNotInStockResponse == 2)
                {
                    MovieBookorMusic();
                }

                else if (userNotInStockResponse == 3)
                {
                    Console.WriteLine("Have a good day!");
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Not a valid response");
                    loop = true;
                }
            }
        }
        public static void ReturnToMainMenuOrExit()
        {
            Console.WriteLine("Would you like to return to the main menu or to exit?");
            string userMainMenuOrExitResponse = Console.ReadLine().ToLower();
            if (userMainMenuOrExitResponse == "main menu" || userMainMenuOrExitResponse == "main" || userMainMenuOrExitResponse == "menu" || userMainMenuOrExitResponse == "y" || userMainMenuOrExitResponse == "yes")
            {
                //Console.Clear();
                AskToSearchReturnOrAdd();
            }

            else if (userMainMenuOrExitResponse == "exit" || userMainMenuOrExitResponse == "n" || userMainMenuOrExitResponse == "no")
            {
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Invalid input");
                ReturnToMainMenuOrExit();
            }
        }
    }
}
