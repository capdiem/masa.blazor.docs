---
category: Components
type: Breadcrumbs
title: Breadcrumbs
cols: 1
related:
  - /components/buttons
  - /components/navigation-drawers
  - /components/icons
---

# Breadcrumbs

Breadcrumbs component is suitable for page-level navigation.

## Usage

By default, breadcrumbs use a text divider. This can be any string.

<breadcrumbs-usage></breadcrumbs-usage>

## API

- [MBreadcrumbs](/api/MBreadcrumbs)
- [MBreadcrumbsItem](/api/MBreadcrumbsItem)

## Caveats

<!--alert:info-->
By default **MBreadcrumbs** will disable the linkage with router. You can enable the feature by using `Linkage` prop.

## Examples

### Props

#### Divider

For the icon variant, breadcrumbs can use any icon in Material Design Icons.

<example file="" />

#### Linkage

<example file="" />

#### Large

Breadcrumbs Basic Usage

<example file="" />

### Contents

#### Icon Dividers

For the icon variant, breadcrumbs can use any icon in Material Design Icons.

<example file="" />

#### Item

You can use the **item** slot to customize each breadcrumb.

<example file="" />