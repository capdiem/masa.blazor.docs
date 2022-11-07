---
category: Components
type: ListItemGroup
title: List item groups
cols: 1
related:
  - /components/lists
  - /components/item-groups
  - /components/cards
---

# List Item Groups

The **MListItemGroup** provides the ability to create a group of selectable **MListItem**. The **MListItemGroup** component
utilizes **MItemGroup** at its core to provide a clean interface for interactive lists.

## Usage

By default, the `ListItemGroup` operates similarly to **ItemGroup**. If a `Value` is not provided, the group will provide a default based upon its index.

<list-item-groups-usage></list-item-groups-usage>

## API

- [MListGroup](/api/MListGroup)
- [MListItem](/api/MListItem)
- [MListItemAction](/api/MListItemAction)
- [MListItemActionText](/api/MListItemActionText)
- [MListItemAvatar](/api/MListItemAvatar)
- [MListItemContent](/api/MListItemContent)
- [MListItemGroup](/api/MListItemGroup)
- [MListItemSubtitle](/api/MListItemSubtitle)
- [MListItemTitle](/api/MListItemTitle)

## Examples

### Props

#### ActiveClass

You can select multiple items at one time.

<example file="" />

#### Mandatory

At least one item must be selected to use the `Multiple` property.

<example file="" />

#### Multiple

Using the `Multiple` property you can select multiple items at once.

<example file="" />

### Misc

#### Flat list

You can easily disable the default highlighting of selected **MListItem**s. This creates a lower profile for a user’s choices.

<example file="" />

#### Selection controls

Using the default slot, you can access an items internal state and toggle it. Since the `Active` property is a boolean, we use the `IsActive` prop on the checkbox to link its state to the **MListItem**.

<example file="" />