# Project Architecture

## Core Classes

### `Item`

`Item` is the base class for all objects offered by customers. It contains:

- a visual representation (`view`)
- the real `price`
- the customer`s claim
- the item's ground-truth `authenticity` 

Item types extend `Item` with properties that can be inspected:

| Class | Additional properties |
|---|---|
| `Bottle` | `Text` |
| `Document` | `Text`, is UV reactive, UV view |
| `Rock` | weight, dimensions, is UV reactive, UV view |
| `Jewellery` | weight, magnetic properties |
| `Statuette` | weight, dimensions, magnetic properties, is UV reactive |

### `Customer`

`Customer` has a `view` variable, basically it connects Item and Claim. Contains a list of (`item`)

### `Claim`

`Claim` stores a text together with the `asking_price`.
_It may differ from the item's actual properties._

## Tools

The player uses tools to reveal item properties:

- `Magnifier`: examines fine details and text
- `Magnet`: checks magnetic properties
- `Scales`: measures weight
- `Ruler`: measures dimensions
- `Lamp`: reveals UV-related information

## Game Flow and Interaction

`GameManager` controls the main game loop:

1. A `Customer` presents an `Item` and its `Claim`.
2. The player uses the available tools to inspect the item.
3. The player compares tool results with the claim.
4. The player accepts or declines the offer.
5. `GameManager` updates the player's money and starts the next offer.


