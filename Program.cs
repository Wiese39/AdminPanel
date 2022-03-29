using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin
{
    class Program
    {
        class MenuItem
        {
            public string Text { get; set; }

            public bool HasSubMenu { get; set; }

            public int? SubMenuId { get; set; }

            public Action<MenuItem> Action { get; set; }
        }
        class Menu
        {
            public Menu()
            {
                MenuItems = new List<MenuItem>();
            }

            public int MenuId { get; set; }
            public List<MenuItem> MenuItems { get; set; }
            public string Title { get; set; }

            public void printToConsole()
            {
                foreach(MenuItem item in MenuItems)
                {
                    Console.WriteLine($"[{MenuItems.IndexOf(item)}]{item.Text}");
                }
            }
        class MenuCollection
            {
                public MenuCollection()
                {
                    Menus = new List<Menu>();
                }
                public List<Menu> Menus { get; set; }
                public void ShowMenu(int id)
                {
                    var currentMenu = Menus.Where(m => m.MenuId == id).Single();
                    currentMenu.printToConsole();

                    string choice = Console.ReadLine();
                    int choiceIndex;
                    if (!int.TryParse(choice, out choiceIndex) || currentMenu.MenuItems.Count < choiceIndex || choiceIndex < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Niet valide!!");
                        ShowMenu(id);
                    }
                    else
                    {
                        var menuItemSelected = currentMenu.MenuItems[choiceIndex];
                        if (menuItemSelected.HasSubMenu)
                        {
                            Console.Clear();
                            ShowMenu(menuItemSelected.SubMenuId.Value);

                        }
                        else
                        {
                            menuItemSelected.Action();
                        }
                    }
                }
            }
            static void Main(string[] args)
            {
                MenuCollection collection = new MenuCollection()
                {
                    Menus =
                    {
                        new Menu()
                        {
                            MenuId = 1,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text = "Go to sub1",
                                    HasSubMenu = true,
                                    SubMenuId = 2
                                },
                                new MenuItem()
                                {
                                    Text = "Lmao",
                                    HasSubMenu= true,
                                    SubMenuId=4
                                    
                                }
                            }

                        },
                        new Menu()
                        {
                            MenuId=2,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text = "Hzallo",
                                    HasSubMenu = true,
                                    SubMenuId = 1


                                }
                            }
                        },
                        new Menu()
                        {
                            MenuId = 3,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text= "Welkomwelkom\nWelkom\ntest\nhallo\n",
                                    HasSubMenu = true,
                                    SubMenuId= 3
                                }
                            }
                        }
                    }
                };
                collection.ShowMenu(0);
                Console.ReadLine();

            }

        }
    }
}