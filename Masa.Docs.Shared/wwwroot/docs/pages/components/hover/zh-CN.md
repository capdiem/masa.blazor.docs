---
category: Components
subtitle: 悬停
type: 悬停
title: Hover
cols: 1
related:
  - /components/cards
  - /components/images
  - /components/tooltips
---

# Hover（悬停）

**MHover** 组件为处理任何组件的悬停状态提供了一个干净的接口。

## 使用

**MHover** 组件是一个包装器，它应该只包含一个子元素并且可以在悬停时可以触发事件。

<hover-usage></hover-usage>

## API

- [MHover](/api/MHover)

## 示例

### 属性

#### 禁用

设置 **Disabled** 属性可以禁用悬停功能。

<example file="" />

#### 打开和关闭延迟

通过组合或单独使用 `OpenDelay` 和 `CloseDelay` 属性延迟 **MHover** 事件。

<example file="" />

### 其他

#### 悬停列表

**MHover** 可以与 for 结合使用，以便在用户与列表交互时突出单个项目。

<example file="" />

#### 过渡

创建高度定制的组件以响应用户交互。

<example file="" />