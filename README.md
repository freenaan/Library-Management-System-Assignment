===== How to Use =====================================

  Data Structure: 
At its core, this program stores three different arraylists of data; an arraylist of items at the library, an arraylist of registered members, and an arraylist detailing borrow records. Upon initial startup, items and members need to be added to the first two arraylists before the third becomes usable. 

Each member and item are assigned a unique user ID and item ID respectively. These can be used to create a borrow record in case a member wants to take out a book, and to update or remove the items. The record can then be labelled as returned using the same user ID and item ID. This does not delete the entry, but rather it persists with the itemReturned variable being swapped to true.

This program has a built in saving system that allows data persistence. Saving occurs automatically after each operation and upon exit, after which the save files are loaded upon the start of the program. In the event that one or more save files are missing, the program will detect this and start with empty arraylists.

  Main Menu: 
The user starts the program at the main menu, where they can access several other menus or save and exit the program. This menu stays in a loop until the program is terminated, upon which data is automatically saved. Data is also saved after an operation is done in case the program crashes or is forced to quit.

  Item and Member Menu: 
The Item and Member menu allows the user to manage all the items and members in the database respectively. Through these menus, they can either add, remove, or update an entry or member. The remove and update entry methods require knowledge of the subject’s ID. The update entry method only allows the user to update certain properties, as some of them will never have to be changed. For instance a member’s date of birth and a book’s author never changed, so in order to edit them the entry has to be deleted and made again.

  View Menu: 
The view menu allows the user to see all members, items, and entries respectively by displaying all of them. It also gives them the option to search for a specific item or user by name and display its properties, in case their ID cannot be found.

  Borrow Menu: 
The borrow menu allows the user to keep track of borrowing records by creating a new borrow entry, and by marking them as returned once the borrower brings the item back. It also includes the option to view all borrow records, which can be seen from the ViewMenu as well.

===== Class structure =====================================

  Class structure overview: 
This program has several different classes to organise code, and create objects. Since the library stores three different types of items, polymorphism was required. This is achieved by using a base class (LibraryItem,) and deriving three subclasses for each three item type, i.e. Book, Magazine, and Dvd. A Member class is also made so that the library can input its members. The Borrow class records transactions, and demonstrates aggregation by storing the borrower and the item being borrowed as objects. The View and UserInterface classes all deal with the user interface, while the Program class handles the data and stores helper methods.

  UserInterface: 
This class is used for the front end. It contains several methods that allow the program to be menu driven. It gives the user an option, then it calls functions from other classes based on the response. In doing so, it fulfils the UI requirements for this assignment.

  Program: 
The Program class is mainly used to store data while the program is running through arraylists. There are three arraylists that each store the library’s items, the library’s members, and the borrow records for members. It also incorporates serialisation by saving these arraylists and the ID generators into four different files using binary formatter. Naturally a method for deserializing files was included as well, which loads save data into the three arraylists upon startup of the program.


  View: 
The View class is a class that the user can use to view the arraylists. It does this by directly accessing them from the Program class, and utilising the ToString() override present to neatly display the entries. In doing so, this class meets the user interface requirements.

  LibraryItem, Book, Magazine, Dvd: 
These four classes demonstrate polymorphism through class inheritance. The LibraryItem class is the superclass, which contains properties shared across all three subclasses. The three subclasses then inherit these properties, and add a few unique properties on top of them. The superclass also contains several functionalities, notably the remove functionality. Rather than outright deleting the entry, the Remove method simply marks the item as deleted through a boolean variable. This will prevent it from appearing when using any methods from the View class, while still allowing the Borrow class to access them after deletion.

This class also demonstrates method overriding by overriding the ToString() Function. The ToString() function is the default method called upon when an object’s method is unspecified. By overriding this, the program makes it easy to display all the attributes of the object by simply typing out its name.

  Member: 
The member class is similar to the LibraryItem class, except there are not any subclasses. This class helps create Member objects to store in the arraylists, which are then recorded when borrowing an item. This class also demonstrates method overriding by overriding the ToString() function.

  Borrow: 
The Borrow class is what makes keeping track of borrowing activities possible. This class demonstrates aggregation by using both the LibraryItem class and the Member Class. The Borrow class pairs up two objects from these classes to create a record of which member borrowed what item. It also uses several other properties to determine when the item was borrowed and returned, and uses ID generators to assign each entry a unique ID.
