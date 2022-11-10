---
category: Components
type: DataIterators
title: Data iterators
cols: 1
related:
  - /components/data-tables
  - /components/simple-tables
  - /components/toolbars
---

# Data iterators

The MDataIterator component is used for displaying data, and shares a majority of its functionality with the MDataTable component. 
Features include sorting, searching, pagination, and selection.

## Uasge

<data-iterators-usage></data-iterators-usage>

## API

- [MDataIterator](/api/MDataIterator)
- [MDataFooter](/api/MDataFooter)

## Examples

### Props

#### Default

The **MDataIterator** has internal state for both selection and expansion, just like **MDataTable**. In this example we use
the methods isExpanded and expand available on the default slot.

<example file="" />

#### Header and footer

The **MDataIterator**  has both a `HeaderContent` and `FooterContent` slot for adding extra content.

<example file="" />

### Misc

#### Filter

Order, filters and pagination can be controlled externally by using the individual props.

<example file="" />