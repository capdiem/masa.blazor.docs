---
category: Components
type: InfiniteScroll
title: Infinite scroll
cols: 1
related:
  - /components/lists
  - /components/progress-circular
  - /components/virtual-scroller
---

# Infinite scroll

Scrolling to the bottom of the list automatically loads more data.

## Usage

When the `HasMore` prop is `true`, the component will call the defined `OnLoadMore` function when the user page scrolls to the bottom `Threshold` (default is 250px). Support click to retry when the request fails.

<infinite-scroll-usage></infinite-scroll-usage>

## API

- [MInfiniteScroll](/api/MInfiniteScroll)

## Examples

### Contents

#### Custom content

<example file="" />

### Misc

#### Use VirtualScroller

<example file="" />


