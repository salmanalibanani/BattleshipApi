# Battleship

## How to run

Simply clone the repository and hit F5 in Visual Studio (I use Professional 2019). You should see Swagger UI.

## Steps to test

- First you need to create a board with POST request (/api/Board). This end point expects board dimentions, e.g.

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

x and y are the starting coordinate of the ship. Orientation is either horizontal (0) or vertical (1). I have implemented some checks, so the ship must fit the board and should not overlap any existing ship.

- At any point you can use the GET request (/api/Board) to get the state of the board. You get a count of ships added to the board, details of all ships, and list of all cells on the board, with a flag to show if that cell was attacked previously. This gives you the complete state of the board.

- Use POST request (/api/board/attack) to attack a cell on the board. Example payload:

```
  {
  "boardId": "2fed94fe-75d7-4c8b-ae56-3a11466da294",
  "x": 1,
  "y": 1
  }
```

If a ship is hit, true is returned, otherwise false.

After the hit, you can query the board again with the GET request to see if the hit was correctly recorded on the board.
