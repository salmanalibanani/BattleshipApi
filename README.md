# Battleship

I have deployed my implementation to Azure:

https://battleshipapi2.azurewebsites.net/swagger/index.html

## How to run

Simply clone the repository and hit F5 in Visual Studio (I use Professional 2019). You should see Swagger UI.

## Steps to test

- First you need to create a board with POST request (/api/Board). This end point expects board dimensions, e.g.

```
{
"width": 10,
"height": 10
}
```

You will receive a board id in response which you will use in subsequent calls.

- Use POST request (api/Ship) to add a ship to the board. The payload looks like this:

```
{
"x": 2,
"y": 3,
"length": 4,
"orientation": 0,
"boardId": "2fed94fe-75d7-4c8b-ae56-3a11466da294"
}
```

Where boardId is the GUID returned in the first API call, and x and y are the starting coordinates of the ship. Orientation is either horizontal (0) or vertical (1).

- At any point you can use the GET request (/api/Board) to get the state of the board. You get a count of ships added to the board, details of all ships, and list of all cells on the board with a flag to show if that cell was attacked previously. This gives you the complete state of the board.

- Use POST request (/api/board/attack) to attack a cell on the board. Example payload:

```
  {
  "boardId": "2fed94fe-75d7-4c8b-ae56-3a11466da294",
  "x": 1,
  "y": 1
  }
```

If a ship is hit, true is returned, otherwise false is returned.

After the hit, you can query the board again with the GET request to see if the hit was correctly recorded on the board.

## Notes

- I have implemented the features requested in the assignment:

1. Create a board
2. Add a battleship to the board
3. Take an "attack" at a given position, and report back whether the attack resulted in a hit or a miss.

In addition to above, I have implemented some safegaurds inline with the rules of the game (e.g. ships can't overlap other ships, they must fit the board) and have ignored situations that are not allowed (e.g. diagonal ships are not allowed as per the rules of the game, so I only allow horizontal or vertical ships to be added to the board).

- Multiple boards are allowed in my implementation. Each time you POST to /api/Board, you get a new board id. The idea here is that in a two players game, you can maintain two boards, and each player can use their board's GUID to maintain the state of play.

- I have used memory cache as a quick way to maintain the state of the board across API calls. A full persistence layer wasn't the requirement of the assignment, and memory cache is probably not the best way to maintain state. A database would suit this application better.

- I have used MediatR to decouple HTTP layer from business logic layer. Probably a bit of an overkill for a small application like this, but I love the decoupling that MediatR provides.
