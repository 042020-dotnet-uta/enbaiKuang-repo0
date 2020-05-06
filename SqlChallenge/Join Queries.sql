Select * From Country, State 
Where Country.countryID = State.countryID And Country = 'US';

Select * 
From Country Join State on Country.countryID = State.countryID;

Select State 
From Country Join State on Country.countryID = State.countryID
Where Country = 'US';