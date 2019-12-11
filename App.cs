using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace library_system
{
    class App
    {
        private string filetype = "JSON";
        private LibraryHelper libraryHelper = new LibraryHelper();
        private List<FictionBook> fictionBooks;
        private List<NonfictionBook> nonfictionBooks;

        public App()
        {

        }

        public void Run()
        {
            CurrentTime time = new CurrentTime();
            while (true)
            {
                Console.Clear();
                time.Update();
                time.Display();

                switch (filetype)
                {
                    case "JSON":
                        if (File.Exists(@"library.json"))
                        {
                            string exisitingData;
                            using (StreamReader reader = new StreamReader(@"library.json", Encoding.Default))
                            {
                                exisitingData = reader.ReadToEnd();
                            }
                            fictionBooks = JsonConvert.DeserializeObject<List<FictionBook>>(exisitingData);
                        }
                        else
                        {
                            fictionBooks = new List<FictionBook>();
                        }
                        break;
                    case "XML":
                        if (File.Exists(@"library.xml"))
                        {
                            var serializer = new XmlSerializer(typeof(List<NonfictionBook>));
                            using (var reader = new StreamReader(@"library.xml"))
                            {
                                try
                                {
                                    fictionBooks = (List<FictionBook>)serializer.Deserialize(reader);
                                }
                                catch
                                {
                                    Console.WriteLine("Could not load file");
                                } // Could not be deserialized to this type.
                            }
                        }
                        else
                        {
                            fictionBooks = new List<FictionBook>();
                            nonfictionBooks = new List<NonfictionBook>();
                        }
                        break;
                }
                bool done = false;

                string another = Input("Add a book y/n");
                if (another == "n")
                {
                    done = true;
                }

                while (!done)
                {
                    Console.Clear();
                    Console.WriteLine("Select a book type: ");
                    Console.WriteLine("1.   Fiction");
                    Console.WriteLine("2.   Non-Fiction");
                    int userBookType = Convert.ToInt32(Console.ReadLine());

                    if (userBookType == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Select a category:");
                        for (int i = 0; i < libraryHelper.Genres.Count; i++)
                        {
                            Console.WriteLine(i + ": " + libraryHelper.Genres[i]);
                        }

                        int selectedGenreID = 0;
                        bool validID = false;
                        do
                        {
                            try
                            {
                                selectedGenreID = Convert.ToInt32(Console.ReadLine());
                                if (selectedGenreID >= 0 && selectedGenreID < libraryHelper.Genres.Count)
                                {
                                    validID = true;
                                }
                                else
                                {
                                    Console.WriteLine("Option not available. Please try again");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                Console.WriteLine("Please try again");
                            }
                        } while (!validID);

                        string selectedGenre = libraryHelper.Genres[selectedGenreID];
                        Console.WriteLine("You have sected {0}", selectedGenre);

                        string title = Input("Title");
                        Console.WriteLine ("How many authors does the book have?");
                        int authorLoopNo = Convert.ToInt32(Console.ReadLine());
                        string author = "";
                        for (int i = 0; i < authorLoopNo; i++)
                        {
                            Console.WriteLine("Enter author with comma at end of name if entering more than one author:");
                            author = author + Console.ReadLine() + " ";
                        }
                        string publisher = Input("Publisher");
                        string dateOfPublication = Input("Date of publication");

                        fictionBooks.Add(new FictionBook(title, author, publisher, dateOfPublication, selectedGenre, BookType.Fiction));

                        another = Input("Add another? y/n");
                        if (another == "n")
                        {
                            done = true;
                        }
                        Console.Clear();
                        Console.WriteLine("All Fiction Books in library\n");
                        foreach (var book in fictionBooks)
                        {
                            book.Display();
                        }
                    }

                    if (userBookType == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Select a category:");
                        for (int i = 0; i < libraryHelper.Categories.Count; i++)
                        {
                            Console.WriteLine(i + ": " + libraryHelper.Categories[i]);
                        }

                        int selectedCategoryID = 0;
                        bool validID = false;
                        do
                        {
                            try
                            {
                                selectedCategoryID = Convert.ToInt32(Console.ReadLine());
                                if (selectedCategoryID >= 0 && selectedCategoryID < libraryHelper.Categories.Count)
                                {
                                    validID = true;
                                }
                                else
                                {
                                    Console.WriteLine("Option not available. Please try again");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                Console.WriteLine("Please try again");
                            }
                        } while (!validID);

                        string selectedCategory = libraryHelper.Genres[selectedCategoryID];
                        Console.WriteLine("You have sected {0}", selectedCategory);

                        string title = Input("Title");
                        Console.WriteLine ("How many authors does the book have?");
                        int authorLoopNo = Convert.ToInt32(Console.ReadLine());
                        string author = "";
                        for (int i = 0; i < authorLoopNo; i++)
                        {
                            Console.WriteLine("Enter author with comma at end of name if entering more than one author:");
                            author = author + Console.ReadLine() + " ";
                        }
                        string publisher = Input("Publisher");
                        string dateOfPublication = Input("Date of publication");

                        nonfictionBooks.Add(new NonfictionBook(title, author, publisher, dateOfPublication, selectedCategory, BookType.NonFiction));

                        another = Input("Add another? y/n");
                        if (another == "n")
                        {
                            done = true;
                        }

                        Console.Clear();
                        Console.WriteLine("All Non-Fiction Books in library\n");
                        foreach (var book in nonfictionBooks)
                        {
                            book.Display();
                        }

                    }




                    if (filetype == "JSON")
                    {
                        using (StreamWriter file = File.CreateText(@"library.json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, fictionBooks);
                        }
                    }

                    if (filetype == "XML")
                    {
                        var serializer = new XmlSerializer(typeof(List<NonfictionBook>));
                        using (var writer = new StreamWriter(@"library.xml"))
                        {
                            serializer.Serialize(writer, fictionBooks);
                        }

                    }

                    //Console.WriteLine(itemsSerialized);
                    Console.ReadKey(true);
                }
            }


        }
        public static string Input(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }
    }
}

