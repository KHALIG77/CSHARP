using System.Drawing;
using ConsoleFinal;
Console.ForegroundColor = ConsoleColor.Blue;

do
{
   MenuMethods.Info();
   

    switch (MenuMethods.MenuInput())
    {
        case 1:
            MenuMethods.MenuCreateGroup();
           
            break;
        case 2:
            MenuMethods.MenuShowAllGroups();
            break;
        case 3:
            MenuMethods.MenuShowEditGroup();
            break;  
        case 4:
            MenuMethods.MenuShowStudentsInGroup();
            break;
        case 5:
            MenuMethods.MenuShowAllStudents();
            break;

        case 6:
            MenuMethods.MenuCreateStudent();
            break;
    }
}while(true);

