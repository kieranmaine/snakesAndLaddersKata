# Snake and Ladders Kata

A windows console app implementing the snakes and ladder game as outlined here http://agilekatas.co.uk/katas/SnakesAndLadders-Kata. Unit tests use NUnit and require an appropriate test runner.

# Approach

Due to the well defined nature of the game I decided to use a strict TDD approach. I let the features guide my creation of unit tests, with the unit tests dicatating the required classes and their structure.

# Key design decisions and alternatives

My main consideration was around how to represent the board and it's associated tokens. Initially I imagined a 2-d 10 x 10 array would be a good representation of the board. However once I started formulating my tests it became apparent that the board was in esscence a 1-d array with a length of 100; also rather than using the Board to keep track of Token locations it was better for each Token to track it's current location.

# Evolving in the future

Apart from implementing the outstanding features (Multiple Players + Computer Controlled Players) I'd add more constraints around where snakes and ladders can start/end, to:
* avoid overlapping snakes + ladders
* stop snakes and ladders starting or ending outside the beginning or end of the board.