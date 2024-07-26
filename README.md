# OSP Post Processing

A [post processing](https://docs.unity3d.com/Packages/com.unity.postprocessing@3.4/manual/index.html) settings menu for [VRChat](https://vrchat.com/) worlds.

Post processing is only available for PC compatible worlds and is not supported on Android and Quest VR.

## Features

- Comprehensive support for settings available in VRChat
- Multiple menus in the same world
- Easy to set default options

## Getting Started

Drag the "Post Processing Volumes" prefab into your scene. Prefabs are found in the folder `Packages/OspPostProcessing/Runtime/Prefabs`.

Choose menu prefabs to add into your scene. Add the menus to the `PostProcessVolumeGroup` component on the volumes prefab.

Add a reference camera to your [scene descriptor](https://creators.vrchat.com/worlds/components/vrc_scenedescriptor/), if you don't already have one. Add a [post-process layer](https://docs.unity3d.com/Packages/com.unity.postprocessing@3.4/manual/Quick-start.html#post-process-layer) to the reference camera. Set the layer to "Water".

Post processing should be visible in the editor. If it's not, check that "Post Processing" is checked in the effects dropdown in the [scene view](https://docs.unity3d.com/Manual/ViewModes.html).

## Setting Defaults

Defaults can be set in the `PostProcessVolumeGroup` component. To make these changes visible in the editor, also change the weight of each Post-process Volume component in the prefab.

## License

This project is licensed under the terms of the [MIT license](LICENSE.md). Fonts are licensed under [Open Font License for Figtree font](Runtime/Fonts/OFL-Figtree.txt) and [OFL for Lexend font](Runtime/Fonts/OFL-Lexend.txt).
