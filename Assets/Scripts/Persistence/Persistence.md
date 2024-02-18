# Persistence / Saving

To add new data to be saved, you must do two things.
* Add fields to GameData for the state you want to save
* Your class which manages this data needs to implement IDataPersistence

**IDataPersistence** just has SaveData and LoadData.  When a save or load is triggered, 
DataPersistenceManager finds all IDataPersistence classes and calls their save/load
methods.  **GameData** holds all game state (only updated on a Save).

**FileDataHandler** saves the state to a file, so you can quit the application and load
the state from a file on the next play.

**DataPersistenceManager** does all of the coordination.  Include it in your scene's 
Managers component.

[@sllewely](https://github.com/sllewely) for help
