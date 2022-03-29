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
                foreach (MenuItem item in MenuItems)
                {
                    if (MenuItems.IndexOf(item) > 0)
                    {
                        Console.WriteLine($"[{MenuItems.IndexOf(item)}]{item.Text}");
                    }
                    else if (MenuItems.IndexOf(item) == 0)
                    {
                        Console.WriteLine(item.Text);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
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
                    var currentMenu = Menus.Where(m => m.MenuId == id).SingleOrDefault();
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
                            Console.Clear();
                            ShowMenu(1);
                        }
                    }
                }
            }
            static void Main(string[] args)
            {
                //Hoofdmenu is MenuId 1
                //Terug naar hoofdmenu is altijd 0 of als er anders staat aangegeven met HasSubMenu = false
                //Index altijd 1 lager dan SubMenuId 1=0, 2=1 etc...
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
                                    Text = "Welkom in het adminpaneel. Hier kan de admin zijn/haar systeem beheren\n\n",
                                    HasSubMenu = true,
                                    SubMenuId = 1
                                },
                                new MenuItem()
                                {
                                    Text = "Beheer 1",
                                    HasSubMenu= true,
                                    SubMenuId=2

                                },
                                new MenuItem()
                                {
                                    Text = "test",
                                    HasSubMenu = true,
                                    SubMenuId = 3
                                },
                                new MenuItem()
                                {
                                    Text = "Films",
                                    HasSubMenu = true,
                                    SubMenuId = 4
                                },
                                new MenuItem()
                                {
                                    Text = "Overzicht gebruikers",
                                    HasSubMenu = true,
                                    SubMenuId = 5
                                },
                                new MenuItem()
                                {
                                    Text = "Uitloggen",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Afsluiten",
                                    HasSubMenu = false,
                                    SubMenuId = -1
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
                                    Text = "Beheer het Admin account\n",
                                    HasSubMenu = true,
                                    SubMenuId = 1


                                },
                                new MenuItem()
                                {
                                    Text = "Test me door te klikken",
                                    HasSubMenu = true,
                                    SubMenuId = 2
                                },
                                new MenuItem()
                                {
                                    Text = "klik mij pls",
                                    HasSubMenu= true,
                                    SubMenuId = 3
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
                                    Text= "Hier kan je het filmaanbod aanpassen",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Overzicht zalen",
                                    HasSubMenu = true,
                                    SubMenuId = 2
                                },
                                new MenuItem()
                                {
                                    Text = "Overzicht reserveringen",
                                    HasSubMenu = true,
                                    SubMenuId = 3
                                }
                            }
                        },
                        new Menu()
                        {
                            MenuId = 4,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text = "Hier kunnen de films aangepast worden\n",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Filmoverzicht",
                                    HasSubMenu = true,
                                    SubMenuId = 5
                                },
                                new MenuItem()
                                {
                                    Text = "Placeholderxx",
                                    HasSubMenu = true,
                                    SubMenuId = 6
                                }
                            }
                        },
                        new Menu()
                        {
                            MenuId = 5,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text = "Hier bevindt zich het filmoverzicht\n",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Films die nu draaien",
                                    HasSubMenu= true,
                                    SubMenuId = 7
                                },
                                new MenuItem()
                                {
                                    Text = "Vorig menu",
                                    HasSubMenu = true,
                                    SubMenuId = 4
                                },
                                new MenuItem()
                                {
                                    Text = "Terug naar hoofdmenu",
                                    HasSubMenu = false
                                }
                            }
                        },
                        new Menu()
                        {
                            MenuId = 6,
                            MenuItems =
                            {
                                new MenuItem()
                                {
                                    Text = "Het menu na de placeholder",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Placeholder 2ofzo",
                                    HasSubMenu = false
                                },
                                new MenuItem()
                                {
                                    Text = "Vorig menu",
                                    HasSubMenu = true,
                                    SubMenuId = 5
                                }
                            }
                        }
                    }
                };
                collection.ShowMenu(1);
                Console.ReadLine();

            }

        }
    }
}