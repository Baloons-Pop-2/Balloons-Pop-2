##### Project refactorings
* Primary refactoring
  - variables' and methods' names changed
  - small performance improvements
  - initial structure not changed
* Some cosmetic changes
  - StyleCop warnings cleared
  - additional renaming
  - new lines and white spaces delted
* Small bug fixed
  - forgotten else 
* Balloons extracted to a clas
* Enumerations for the traversal patterns created
* Extracted the UI logic
  - abstract drawer created
  - abstract reader created
* ICommand interface created
  - preparation for the Command pattern 
* Board that holds balloons extracted to a separate class
* All messages used in the game extracted to a static class
* Refactoring the exisitng code
  - methods renamed
  - variables renamed
  - all static methods from the Program class are moved to their parent classes and not static now
* Commented out code deleted
* BalloonPopper class introduced
  - manager for the balloon popping 
* Enumeration for traversal effects removed
  - Abstract class for the traversal effects created
  - each traversal effect now is a different class, which allows polymorphism
* Commands created
* All game logic extracted to the GameEngine class
* BalloonPopManager removed
  - The pop command is responsible for the balloon popping 
* CommandContext created
* Struncture Refactoring
  -  Project renamed
  -  Extracted classes to class library
* Logger adapter
  - using log4net 
* Factories
  - Ballon factory (flyweight)
  - Effect factory (flyweight)
  - Command factory (flyweight)
* Memento implemented
  - memento object
  - memento director
* Small refacotrings
  - removed unused Board constructor
  - removed Ninject (we failed :( )
* Fixed ISP violations with recently introduced memento pattern
* Added dependency container
* Refactoring of GameEngine, ConsoleInputHandler and CommandContext
  - game messages moved from static class to CommandContext
* WPF project introduced
* Fixed the majority of stylecop warnings on Lib and ConsoleApp projects
* Graphics project refactored
* Highscore class created
* Highscore class changed to singleton
* Highscore now has fluent interface
* Show highscore command implemented
* Created highscore processor
  - for saving highscores in XML file
  - for loading highscores from XML file
* RandomGenerator is now as dependency for the board
* StyleCop warnings fixed
