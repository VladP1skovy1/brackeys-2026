# Trust No One. Architecture & Functional Requirements

**Project:** Antique Shop

**Engine:** Unity

---

## 1. Overview

The player works in an antique shop. Customers arrive one at a time, present an item with a spoken claim about it (material, size, origin, age) and name a price. The player may inspect the item with a set of physical tools, then **accept** or **decline** the offer.

The core tension: the customer's *claim* and the item's *truth* are two separate pieces of data. Every deal is a bet on information retrieved with tools.

**Win condition:** reach the quota (e.g. $50,000 net profit) before the day ends.

**Lose condition:** the deadline passes with the quota unmet.

---

## 2. Functional Requirements

### 2.1 Item & Claim

| ID | Requirement                                                                                                                                   |
|----|-----------------------------------------------------------------------------------------------------------------------------------------------|
| FR-1.1 | Each item belongs to one of the categories: **alcohol**, **jewellery**, **rock**, **statuette**, **document**.                                |
| FR-1.2 | An item is defined by a set of **ground-truth properties** (e.g. `material=Iron`, `height=9cm`, `mass=610g`, `hallmark=present`, `uv=false`). |
| FR-1.3 | Each item has a **claim**: the customer's version of a subset of those properties, plus an asking price.                                      |
| FR-1.4 | An item is **fake** if at least one claimed property contradicts the ground truth. Otherwise it is **authentic**.                             |
| FR-1.5 | Each item has a `trueMarketValue` used to compute profit on accepted authentic items.                                                         |

### 2.2 Tools

| ID | Requirement |
|----|-------------|
| FR-2.1 | The player has five tools: **magnifier**, **magnet**, **scales**, **ruler**, **lamp** (UV/backlight). |
| FR-2.2 | Each tool declares which property types it can read. A tool applied to an item returns a `ToolReading` or "no useful result". |
| FR-2.3 | Tool readings reflect **ground truth**. |

**Tool: property coverage:**

| Tool | Alcohol     | Jewellery | Statuette | Document       | Rock            |
|------|-------------|-----------|-----------|----------------|-----------------|
| Magnifier | label print | x | x | whole document | x               |
| Magnet | x           | gold/silver must be non-magnetic | ferromagnetic yes/no | x              | contains Ferrum |
| Scales | x           | mass | mass | x              | mass |
| Ruler | dimensions  | dimensions | dimensions | x              | dimensions |
| Lamp | x           | gemstone fluorescence | x | watermark      | gemstone fluorescence |

### 3.3 Offer

| ID | Requirement |
|----|-------------|
| FR-3.1 | The HUD shows a live **potential outcome** label in the top-left: `+(trueMarketValue − askingPrice)` if object authentic. |
| FR-3.2 | Accept + authentic -> `cash += trueMarketValue − askingPrice`. Shown in the HUD. |
| FR-3.3 | Accept + fake -> `cash −= askingPrice`. |
| FR-3.4 | Decline + fake -> no cash change. |
| FR-3.5 | Decline + authentic -> no cash change. |
| FR-3.6 | After accept/decline -> several seconds before next customer, money update visual. |

### 3.4 Presentation

| ID     | Requirement                                                                                 |
|--------|---------------------------------------------------------------------------------------------|
| FR-5.1 | The customer's text is shown as text dialogue, the claim is visual all the time.            |
| FR-5.2 | Possible gain is shown in top left corner.                                                  |
| FR-5.3 | Quota is shown in top right corner.                                                         |
| FR-5.4 | When User uses Magnifier Sub-window is shown under quota label on right side of the screen. |
