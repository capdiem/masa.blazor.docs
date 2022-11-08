---
category: Components
subtitle: 图片验证码
type: 图片验证码
title: Image Captcha
cols: 1
tag: preset
related:
  - /components/text-fields
  - /components/image
---

# Image Captcha（图片验证码）

提供生成图片验证码的组件。

## 使用

**PImageCaptcha** 是使用`SkiaSharp` 生成的图片，在Linux环境中，需要安装 `libfontconfig1`，如Dockerfile中增加 `RUN apt-get update && apt-get install -y libfontconfig1`。

<image-captcha-usage></image-captcha-usage>

## 示例

### 属性

#### TextField 样式

<example file="" />

#### 自定义验证码结果

<example file="" />