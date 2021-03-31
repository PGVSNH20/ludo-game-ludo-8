[
  {
    "name": "Board",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "knows how many players there are in the game",
      "knows how many moves a player has taken",
      "knows when to move pieces after dice is rolled"
    ],
    "collaborators": [
      "Player",
      "Piece",
      "Move",
      "Dice"
    ]
  },
  {
    "name": "Player",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "know player ID",
      "know name of player",
      "know win/loss stats of player"
    ],
    "collaborators": [
      "Piece"
    ]
  },
  {
    "name": "Move",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "knows how to react when the value of the dice is returned",
      "knows which player to move"
    ],
    "collaborators": [
      "Dice",
      "Board",
      "Piece"
    ]
  },
  {
    "name": "Piece",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "knows the connection between pieces and players by color",
      "knows what piece is moved",
      ""
    ],
    "collaborators": [
      "Move",
      "Player",
      "Board"
    ]
  },
  {
    "name": "Dice",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "Knows how many steps a piece can move by randomizing a number between 1-6"
    ],
    "collaborators": [
      "Move",
      "Piece"
    ]
  },
  {
    "name": "Program",
    "superclasses": "",
    "subclasses": "",
    "type": 1,
    "responsibilities": [
      "Responsible for gluing all classes together to a working game",
      "Responsible for menu"
    ],
    "collaborators": [
      "All other classes"
    ]
  }
]
