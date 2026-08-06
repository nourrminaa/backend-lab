namespace IDS_API_Project.Models;

/* API data is usually received, processed and sent without needing to be
   modified after it is created. */

/* For this reason, we can use 'Records'.
   Records are types (derived from classes) designed for representing data. 
   They mainly used for models that store data.

   Positional Records create init-only properties by default, meaning their
   values can be assigned only when the object is created. This helps keep
   the data 'immutable' and prevents accidental modifications. */

/* Records also provide useful built-in functionality such as a readable
   ToString() method, which allows us to easily inspect their contents
   without writing additional code. */

public record DataItem(int Id, string Name, string Description);
