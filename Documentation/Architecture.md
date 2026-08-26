# Project Architecture

## Core Classes

### `Item`

`Item` is the base class for all objects offered by customers. It contains:

- a visual representation (`view`)
- the asking `price`
- the item's ground-truth `authenticity` (maybe implemented as a method: `this.isAuthentic(claim)`)

Item types extend `Item` with properties that can be inspected:

| Class | Additional properties |
|---|---|
| `Bottle` | `Text`, dimensions |
| `Document` | `Text`, UV information, UV view |
| `Rock` | weight, dimensions, UV information, visual and UV views |
| `Jewellery` | weight, magnetic properties |
| `Statuette` | weight, dimensions, magnetic properties |

### `Customer`

`Customer` has a `view` variable, basically it connects Item and Claim. Contains a list of pairs (`item`, `claim`)

### `Claim`

`Claim` stores a dictionary of the properties stated by the customer, such as weight,
dimensions, and magnetic properties, together with the `asking_price`.
It may differ from the item's actual properties.

### `Text`

`Text` contains textual metadata associated with an item, such as its date and
country of origin.

## Tools

The player uses tools to reveal item properties:

- `Magnifier`: examines fine details and text
- `Magnet`: checks magnetic properties
- `Scales`: measures weight
- `Ruler`: measures dimensions
- `Lamp`: reveals UV-related information

Tools read the item's actual properties. Their results are compared with the
customer's `Claim` to help determine whether the item is authentic.

## Game Flow and Interaction

`GameManager` controls the main game loop:

1. A `Customer` presents an `Item` and its `Claim`.
2. The player uses the available tools to inspect the item.
3. The player compares tool results with the claim.
4. The player accepts or declines the offer.
5. `GameManager` updates the player's money and starts the next offer.

`GameManager` has a list of customers that is created in the init state.

